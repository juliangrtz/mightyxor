// Copyright (C) 1997-2019, Torben Aberspach
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
namespace MightyXOR.Core.Libraries.naPRNGs;

/// <summary>
///     naStrict, non-arithmetic random generators in strict mode.
/// </summary>
/// <remarks>
///     An implementation to provide all naPRNGs in strict mode derived from naRND&lt;byte&gt;.
///     The items represent exactly the numbers from 0 to NumberOfReferences-1.
/// </remarks>
public class naStrict
{
    /// <summary>
    ///     Default file extension.
    /// </summary>
    public const string FileExtension = ".nastrict";

    /// <summary>
    ///     Predefined values for number of substitution boxes.
    /// </summary>
    public const int
        MinimumNumberOfSubstitutionBoxes = naRND<byte>.MinimumNumberOfSubstitutionBoxes,
        MaximumNumberOfSubstitutionBoxes = naRND<byte>.MaximumNumberOfSubstitutionBoxes,
        DefaultNumberOfSubstitutionBoxes = naRND<byte>.DefaultNumberOfSubstitutionBoxes;

    /// <summary>
    ///     Predefined values for number of elements.
    /// </summary>
    public const int
        MinimumNumberOfReferences = naRND<byte>.MinimumNumberOfReferences,
        MaximumNumberOfReferences = 256,
        DefaultNumberOfReferences = 256;

    /// <summary>
    ///     Operation mode.
    /// </summary>
    public readonly OperationModes OperationMode;

    /// <summary>
    ///     Internal naPRNG.
    /// </summary>
    private naRND<byte> naPRNG;

    /// <summary>
    ///     Create a new instance of naStrict with default dimensions.
    /// </summary>
    /// <param name="OperationMode"></param>
    public naStrict(OperationModes OperationMode)
    {
        this.OperationMode = OperationMode;
        Initialize(DefaultNumberOfSubstitutionBoxes, DefaultNumberOfReferences);
    }

    /// <summary>
    ///     Create a deep clone.
    /// </summary>
    /// <param name="naPRNG"></param>
    private naStrict(naRND<byte> naPRNG)
    {
        OperationMode = naPRNG.OperationMode;
        this.naPRNG = naPRNG.DeepClone();
    }

    /// <summary>
    ///     Number of substitution boxes.
    /// </summary>

    public int NumberOfSubstitutionBoxes => naPRNG.NumberOfSubstitutionBoxes;

    /// <summary>
    ///     Number of references.
    /// </summary>

    public int NumberOfReferences => naPRNG.NumberOfReferences;

    /// <summary>
    ///     Current random value.
    /// </summary>

    public byte CurrentRandomValue => naPRNG.RandomItem;

    /// <summary>
    ///     True, if secure random is available.
    /// </summary>
    /// <remarks>
    ///     True, if number of references is a power of two.
    /// </remarks>

    public bool ProvidesSecureRandom => (NumberOfReferences & (NumberOfReferences - 1)) == 0;

    /// <summary>
    ///     Current secure random value.
    /// </summary>
    /// <exception cref="NotSupportedException"></exception>

    public byte CurrentSecureValue
    {
        get
        {
            if (!ProvidesSecureRandom) throw new NotSupportedException("naPRNG: !ProvidesSecureRandom");
            return (byte)(naPRNG.IteratorItem ^ naPRNG.LastItem);
        }
    }

    /// <summary>
    ///     Get a deep clone.
    /// </summary>
    /// <returns></returns>
    public naStrict DeepClone()
    {
        return new naStrict(naPRNG);
    }

    /// <summary>
    ///     Initialize in strict mode with given dimensions.
    /// </summary>
    /// <param name="NumberOfSubstitutionBoxes">
    ///     MinimumNumberOfSubstitutionBoxes &lt;= NumberOfSubstitutionBoxes &lt;=
    ///     MaximumNumberOfSubstitutionBoxes.
    /// </param>
    /// <param name="NumberOfReferences">MinimumNumberOfReferences &lt;= NumberOfReferences &lt;= MaximumNumberOfReferences.</param>
    /// <param name="InitializeByIdentity">If true, the naPRNG is intitialized by identity, else it is initialized by random.</param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    public void Initialize(int NumberOfSubstitutionBoxes, int NumberOfReferences, bool InitializeByIdentity = false)
    {
        if (NumberOfSubstitutionBoxes < MinimumNumberOfSubstitutionBoxes ||
            NumberOfSubstitutionBoxes > MaximumNumberOfSubstitutionBoxes)
            throw new ArgumentOutOfRangeException("NumberOfSubstitutionBoxes: " + NumberOfSubstitutionBoxes);
        if (NumberOfReferences < MinimumNumberOfReferences || NumberOfReferences > MaximumNumberOfReferences)
            throw new ArgumentOutOfRangeException("NumberOfReferences: " + NumberOfReferences);

        var SubstitutionBoxes = new int[NumberOfSubstitutionBoxes][];
        if (InitializeByIdentity)
            for (var Index = 0; Index < NumberOfSubstitutionBoxes; Index++)
                SubstitutionBoxes[Index] = naTools.GetIdentityIntegers(NumberOfReferences);
        else
            for (var Index = 0; Index < NumberOfSubstitutionBoxes; Index++)
                SubstitutionBoxes[Index] = naTools.GetRandomPermutation(NumberOfReferences);

        var SubstitutionBoxIterator = InitializeByIdentity ? 0 : naPool.NextRandomInt32(NumberOfSubstitutionBoxes);
        var ReferenceIterator = InitializeByIdentity ? 0 : naPool.NextRandomInt32(NumberOfReferences);
        var LastReference = InitializeByIdentity ? 0 : naPool.NextRandomInt32(NumberOfReferences);

        Initialize(SubstitutionBoxes, SubstitutionBoxIterator, ReferenceIterator, LastReference);
    }

    /// <summary>
    ///     Initialize in strict mode by substitution boxes, iterators and last reference.
    /// </summary>
    /// <param name="SubstitutionBoxes">
    ///     SubstitutionBoxes[NumberOfSubstitutionBoxes][NumberOfReferences],
    ///     MinimumNumberOfSubstitutionBoxes &lt;= NumberOfSubstitutionBoxes &lt;= MaximumNumberOfSubstitutionBoxes and
    ///     MinimumNumberOfReferences &lt;= NumberOfReferences &lt;= MaximumNumberOfReferences.
    /// </param>
    /// <param name="SubstitutionBoxIterator">0 &lt;= SubstitutionBoxIterator &lt; NumberOfSubstitutionBoxes.</param>
    /// <param name="ReferenceIterator">0 &lt;= ReferenceIterator &lt; NumberOfReferences.</param>
    /// <param name="LastReference">0 &lt;= LastReference &lt; NumberOfReferences.</param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    /// <exception cref="ArrayTypeMismatchException"></exception>
    public void Initialize(int[][] SubstitutionBoxes, int SubstitutionBoxIterator, int ReferenceIterator,
        int LastReference)
    {
        var NumberOfSubstitutionBoxes = SubstitutionBoxes.Length;
        var NumberOfReferences = SubstitutionBoxes[0].Length;

        if (NumberOfSubstitutionBoxes < MinimumNumberOfSubstitutionBoxes ||
            NumberOfSubstitutionBoxes > MaximumNumberOfSubstitutionBoxes)
            throw new ArgumentOutOfRangeException("NumberOfSubstitutionBoxes: " + NumberOfSubstitutionBoxes);
        if (NumberOfReferences < MinimumNumberOfReferences || NumberOfReferences > MaximumNumberOfReferences)
            throw new ArgumentOutOfRangeException("NumberOfReferences: " + NumberOfReferences);

        var ItemBoxes = new byte[NumberOfSubstitutionBoxes][];
        for (var Index = 0; Index < NumberOfSubstitutionBoxes; Index++)
            ItemBoxes[Index] = naTools.GetIdentityBytes(NumberOfReferences);
        naPRNG = new naRND<byte>(OperationMode, ItemBoxes, SubstitutionBoxes, SubstitutionBoxIterator,
            ReferenceIterator, LastReference);
    }

    /// <summary>
    ///     Check naPRNG for internal restrictions.
    /// </summary>
    /// <param name="naPRNG"></param>
    /// <returns></returns>
    private bool IsValidState(naRND<byte> naPRNG)
    {
        if (naPRNG.OperationMode != OperationMode || !naTools.IsStrict(naPRNG)) return false;
        if (naPRNG.NumberOfReferences < MinimumNumberOfReferences ||
            naPRNG.NumberOfReferences > MaximumNumberOfReferences) return false;
        return true;
    }

    /// <summary>
    ///     Load state from disk.
    /// </summary>
    /// <param name="FileName"></param>
    /// <exception cref="NotSupportedException"></exception>
    public void Load(string FileName)
    {
        if (!(FileName.EndsWith(FileExtension) || FileName.EndsWith(naCrypt.FileExtension)))
            throw new NotSupportedException("FileType: Extension");
        naPRNG = naTools.Load(FileName);
        if (!IsValidState(naPRNG)) throw new NotSupportedException("FileType: !IsValidState");
    }

    /// <summary>
    ///     Load state and additional data from disk.
    /// </summary>
    /// <param name="FileName"></param>
    /// <param name="NumberOfBytes"></param>
    /// <param name="AdditionalData"></param>
    /// <exception cref="NotSupportedException"></exception>
    public void Load(string FileName, int NumberOfBytes, out byte[] AdditionalData)
    {
        if (!(FileName.EndsWith(FileExtension) || FileName.EndsWith(naCrypt.FileExtension)))
            throw new NotSupportedException("FileType: Extension");
        AdditionalData = new byte[0];
        naPRNG = naTools.Load(FileName, NumberOfBytes, out AdditionalData);
        if (!IsValidState(naPRNG)) throw new NotSupportedException("FileType: !IsValidState");
    }

    /// <summary>
    ///     Save state to disk.
    /// </summary>
    /// <param name="FileName"></param>
    /// <param name="AdditionalData"></param>
    public void Save(string FileName, byte[] AdditionalData = null)
    {
        if (!(FileName.EndsWith(FileExtension) || FileName.EndsWith(naCrypt.FileExtension))) FileName += FileExtension;
        naTools.Save(naPRNG, FileName, AdditionalData);
    }

    /// <summary>
    ///     Get visualization of the naPRNG.
    /// </summary>
    public string Visualization()
    {
        return naTools.GetVisualization(naPRNG);
    }

    /// <summary>
    ///     Get notation of the naPRNG.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return naTools.GetNotation(naPRNG);
    }

    /// <summary>
    ///     Gather entropy.
    /// </summary>
    /// <param name="Data"></param>
    /// <param name="Repeat"></param>
    public void GatherEntropy(int Data, byte Repeat = 0)
    {
        naPRNG.GatherEntropy(Data, Repeat);
    }

    /// <summary>
    ///     Get previous random value.
    /// </summary>
    /// <returns></returns>
    public byte PreviousRandomValue()
    {
        naPRNG.SetPreviousState();
        return CurrentRandomValue;
    }

    /// <summary>
    ///     Get next random value.
    /// </summary>
    /// <returns></returns>
    public byte NextRandomValue()
    {
        naPRNG.SetNextState();
        return CurrentRandomValue;
    }

    /// <summary>
    ///     Get next secure random value.
    /// </summary>
    /// <returns></returns>
    public byte NextSecureValue()
    {
        naPRNG.SetNextState();
        return CurrentSecureValue;
    }
}
#pragma warning restore