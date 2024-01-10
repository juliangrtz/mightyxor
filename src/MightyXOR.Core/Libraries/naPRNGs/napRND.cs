// Copyright (C) 2016-2019, Torben Aberspach
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without modification,
// are permitted provided that the following conditions are met:
//
// 1. Redistributions of source code must retain the above copyright notice, this
//    list of conditions and the following disclaimer.
// 2. Redistributions in binary form must reproduce the above copyright notice,
//    this list of conditions and the following disclaimer in the documentation
//    and/or other materials provided with the distribution.
// 3. Neither the name of the organisation nor the names of its contributors may
//    be used to endorse or promote products derived from this software without
//    specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
// ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.
// IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT,
// INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING,
// BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
// DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
// LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE
// OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED
// OF THE POSSIBILITY OF SUCH DAMAGE.
//
// Any feedback is very welcome.
// http://www.naRND.de/
#pragma warning disable
namespace MightyXOR.Core.Libraries.naPRNGs
{
    /// <summary>
    /// napRND, non-arithmetic parallel random.
    /// </summary>
    /// <remarks>
    /// Simulation of a parallel version of naPRNGs derived from naRND&lt;byte&gt;.
    /// Using strict mode and only one substitution box for the single naPRNGs.
    /// </remarks>

    public class napRND
    {
        /// <summary>
        /// Operation mode.
        /// </summary>

        public readonly OperationModes OperationMode;

        /// <summary>
        /// Number of parallel PRNGs.
        /// </summary>

        public int NumberOfSubstitutionBoxes { get; private set; }

        /// <summary>
        /// Number of references.
        /// </summary>

        public int NumberOfReferences { get; private set; }

        /// <summary>
        /// Predefined values for number of parallel PRNGs.
        /// </summary>

        public const int
            MinimumNumberOfSubstitutionBoxes = naStrict.MinimumNumberOfSubstitutionBoxes,
            MaximumNumberOfSubstitutionBoxes = naStrict.MaximumNumberOfSubstitutionBoxes,
            DefaultNumberOfSubstitutionBoxes = naStrict.DefaultNumberOfSubstitutionBoxes;

        /// <summary>
        /// Predefined values for number of elements.
        /// </summary>

        public const int
            MinimumNumberOfReferences = naStrict.MinimumNumberOfReferences,
            MaximumNumberOfReferences = naStrict.MaximumNumberOfReferences,
            DefaultNumberOfReferences = naStrict.DefaultNumberOfReferences;

        /// <summary>
        /// Internal napPRNG.
        /// </summary>

        private naRND<byte>?[] naPRNGs;

        /// <summary>
        /// Create a new instance of napRND with default dimensions.
        /// </summary>
        /// <param name="OperationMode"></param>

        public napRND(OperationModes OperationMode)
        {
            this.OperationMode = OperationMode;
            Initialize(DefaultNumberOfSubstitutionBoxes, DefaultNumberOfReferences, false);
        }

        /// <summary>
        /// Initialize in strict mode with given dimensions.
        /// </summary>
        /// <param name="NumberOfSubstitutionBoxes">MinimumNumberOfSubstitutionBoxes &lt;= NumberOfSubstitutionBoxes &lt;= MaximumNumberOfSubstitutionBoxes.</param>
        /// <param name="NumberOfReferences">MinimumNumberOfReferences &lt;= NumberOfReferences &lt;= MaximumNumberOfReferences.</param>
        /// <param name="InitializeByIdentity">If true, the naPRNG is intitialized by identity, else it is initialized by random.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>

        public void Initialize(int NumberOfSubstitutionBoxes, int NumberOfReferences, bool InitializeByIdentity)
        {
            if (NumberOfSubstitutionBoxes < MinimumNumberOfSubstitutionBoxes || NumberOfSubstitutionBoxes > MaximumNumberOfSubstitutionBoxes) throw new ArgumentOutOfRangeException("NumberOfSubstitutionBoxes: " + NumberOfSubstitutionBoxes);
            if (NumberOfReferences < MinimumNumberOfReferences || NumberOfReferences > MaximumNumberOfReferences) throw new ArgumentOutOfRangeException("NumberOfReferences: " + NumberOfReferences);

            int[]?[] SubstitutionBoxes = new int[NumberOfSubstitutionBoxes][];
            if (InitializeByIdentity) for (int Index = 0; Index < NumberOfSubstitutionBoxes; Index++) SubstitutionBoxes[Index] = naTools.GetIdentityIntegers(NumberOfReferences);
            else for (int Index = 0; Index < NumberOfSubstitutionBoxes; Index++) SubstitutionBoxes[Index] = naTools.GetRandomPermutation(NumberOfReferences);

            int[] LastReferences = new int[NumberOfSubstitutionBoxes];
            for (int Index = 0; Index < NumberOfSubstitutionBoxes; Index++) LastReferences[Index] = (InitializeByIdentity) ? 0 : naPool.NextRandomInt32(NumberOfReferences);

            int ReferenceIterator = (InitializeByIdentity) ? 0 : naPool.NextRandomInt32(NumberOfReferences);
            Initialize(SubstitutionBoxes, LastReferences, ReferenceIterator);
        }

        /// <summary>
        /// Initialize in strict mode by substitution boxes, last references and common reference iterator.
        /// </summary>
        /// <param name="SubstitutionBoxes">SubstitutionBoxes[NumberOfSubstitutionBoxes][NumberOfReferences], MinimumNumberOfSubstitutionBoxes &lt;= NumberOfSubstitutionBoxes &lt;= MaximumNumberOfSubstitutionBoxes and MinimumNumberOfReferences &lt;= NumberOfReferences &lt;= MaximumNumberOfReferences.</param>
        /// <param name="LastReferences">LastReferences[NumberOfSubstitutionBoxes].</param>
        /// <param name="ReferenceIterator">0 &lt;= ReferenceIterator &lt; NumberOfReferences.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArrayTypeMismatchException"></exception>

        public void Initialize(int[]?[] SubstitutionBoxes, int[] LastReferences, int ReferenceIterator)
        {
            NumberOfSubstitutionBoxes = SubstitutionBoxes.Length;
            NumberOfReferences = SubstitutionBoxes[0].Length;

            if (NumberOfSubstitutionBoxes < MinimumNumberOfSubstitutionBoxes || NumberOfSubstitutionBoxes > MaximumNumberOfSubstitutionBoxes) throw new ArgumentOutOfRangeException("NumberOfSubstitutionBoxes: " + NumberOfSubstitutionBoxes);
            if (NumberOfReferences < MinimumNumberOfReferences || NumberOfReferences > MaximumNumberOfReferences) throw new ArgumentOutOfRangeException("NumberOfReferences: " + NumberOfReferences);

            naPRNGs = new naRND<byte>?[NumberOfSubstitutionBoxes];
            for (int Index = 0; Index < NumberOfSubstitutionBoxes; Index++)
            {
                int[]?[] SubstitutionBox = new int[1][];
                SubstitutionBox[0] = SubstitutionBoxes[Index];

                byte[][] ItemBoxes = new byte[1][];
                ItemBoxes[0] = naTools.GetIdentityBytes(NumberOfReferences);

                int LastReference = LastReferences[Index];
                naPRNGs[Index] = new naRND<byte>(OperationMode, ItemBoxes, SubstitutionBox, 0, ReferenceIterator, LastReference);
            }

            // This step assures the necessary asymmetry.
            naPRNGs[0].SetNextState();
        }

        /// <summary>
        /// Check naPRNGs for internal restrictions.
        /// </summary>
        /// <param name="naPRNGs"></param>
        /// <returns></returns>

        private bool IsValidState(naRND<byte>?[] naPRNGs)
        {
            NumberOfSubstitutionBoxes = naPRNGs.Length;
            NumberOfReferences = naPRNGs[0].NumberOfReferences;
            if (NumberOfSubstitutionBoxes < MinimumNumberOfSubstitutionBoxes || NumberOfSubstitutionBoxes > MaximumNumberOfSubstitutionBoxes) return false;
            if (NumberOfReferences < MinimumNumberOfReferences || NumberOfReferences > MaximumNumberOfReferences) return false;
            for (int Index = 0; Index < NumberOfSubstitutionBoxes; Index++)
            {
                if (naPRNGs[Index].OperationMode != OperationMode || !naTools.IsStrict(naPRNGs[Index])) return false;
                if (naPRNGs[Index].NumberOfSubstitutionBoxes != 1) return false;
            }
            for (int Index = 1; Index < NumberOfSubstitutionBoxes; Index++)
            {
                if (naPRNGs[Index - 1].NumberOfReferences != naPRNGs[Index].NumberOfReferences) return false;
                int ReferenceIterator = (naPRNGs[Index].ReferenceIterator + 1) % NumberOfReferences;
                if (ReferenceIterator != naPRNGs[0].ReferenceIterator) return false;
            }
            return true;
        }

        /// <summary>
        /// Get visualization of the napPRNG.
        /// </summary>

        public string Visualization()
        {
            return naTools.GetVisualization(naPRNGs);
        }

        /// <summary>
        /// Get notation of the napPRNG.
        /// </summary>
        /// <returns></returns>

        public override string ToString()
        {
            return naTools.GetNotation(naPRNGs);
        }

        /// <summary>
        /// Current random values.
        /// </summary>

        public byte[] CurrentRandomValues
        {
            get
            {
                byte[] Result = new byte[NumberOfSubstitutionBoxes];
                for (int Index = 0; Index < NumberOfSubstitutionBoxes; Index++) Result[Index] = naPRNGs[Index].RandomItem;
                return Result;
            }
        }

        /// <summary>
        /// Get next random values.
        /// </summary>
        /// <returns></returns>

        public byte[] NextRandomValues()
        {
            int[] LastReference = new int[NumberOfSubstitutionBoxes];
            for (int Index = 0; Index < NumberOfSubstitutionBoxes; Index++) LastReference[Index] = naPRNGs[Index].LastReference;
            for (int Index = 0; Index < NumberOfSubstitutionBoxes; Index++)
            {
                int Previous = (Index + NumberOfSubstitutionBoxes - 1) % NumberOfSubstitutionBoxes;
                naPRNGs[Index].SetLastReference(LastReference[Previous]);
                naPRNGs[Index].SetNextState();
            }
            return CurrentRandomValues;
        }
    }
}
#pragma warning restore