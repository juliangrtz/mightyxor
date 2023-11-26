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
namespace Amgine.Core.Libraries.naPRNGs
{
    /// <summary>
    /// naPool, non-arithmetic random pool.
    /// </summary>
    /// <remarks>
    /// A static implementation of naRND&lt;byte&gt; [V2, Strict] [4, 256]. Supposed to be thread-safe.
    /// </remarks>

    public static class naPool
    {
        /// <summary>
        /// Default filename.
        /// </summary>

        public static readonly string FileEntropyPool =
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\entropy.napool";

        /// <summary>
        /// Default operation mode.
        /// </summary>

        public const OperationModes OperationMode = OperationModes.V2;

        /// <summary>
        /// Default values for number of substitution boxes and number of references.
        /// </summary>

        public const int
            NumberOfSubstitutionBoxes = 4,
            NumberOfReferences = 256;

        /// <summary>
        /// Internal naPRNG.
        /// </summary>

        private static naRND<byte>? naPRNG;
        private static readonly object _Locker = new object();

        /// <summary>
        /// Initialize.
        /// </summary>

        static naPool()
        {
            lock (_Locker)
            {
                try { Load(); }
                catch { Initialize(); }
            }
        }

        /// <summary>
        /// Initialize by system PRNG.
        /// </summary>

        private static void Initialize()
        {
            Random? SystemRND = new Random();

            int[]?[] SubstitutionBoxes = new int[NumberOfSubstitutionBoxes][];
            for (int Index = 0; Index < NumberOfSubstitutionBoxes; Index++) SubstitutionBoxes[Index] = naTools.GetRandomPermutation(NumberOfReferences, SystemRND);

            byte[][] ItemBoxes = new byte[NumberOfSubstitutionBoxes][];
            for (int Index = 0; Index < NumberOfSubstitutionBoxes; Index++) ItemBoxes[Index] = naTools.GetIdentityBytes(NumberOfReferences);

            int SubstitutionBoxIterator = SystemRND.Next(NumberOfSubstitutionBoxes);
            int ReferenceIterator = SystemRND.Next(NumberOfReferences);
            int LastReference = SystemRND.Next(NumberOfReferences);

            naPRNG = new naRND<byte>(OperationMode, ItemBoxes, SubstitutionBoxes, SubstitutionBoxIterator, ReferenceIterator, LastReference);
        }

        /// <summary>
        /// Check naPRNG for internal restrictions.
        /// </summary>
        /// <param name="naPRNG"></param>
        /// <returns></returns>

        private static bool IsValidState(naRND<byte>? naPRNG)
        {
            if (naPRNG.OperationMode != OperationMode || !naTools.IsStrict(naPRNG)) return false;
            if (naPRNG.NumberOfSubstitutionBoxes != NumberOfSubstitutionBoxes || naPRNG.NumberOfReferences != NumberOfReferences) return false;
            return true;
        }

        /// <summary>
        /// Load state from disk.
        /// </summary>
        /// <exception cref="NotSupportedException"></exception>

        private static void Load()
        {
            naPRNG = naTools.Load(FileEntropyPool);
            if (!IsValidState(naPRNG)) throw new NotSupportedException("FileType: !IsValidState");
        }

        /// <summary>
        /// Save state to disk. Has to be called explicitely.
        /// </summary>

        public static void Flush()
        {
            lock (_Locker)
            {
                naTools.Save(naPRNG, FileEntropyPool);
            }
        }

        /// <summary>
        /// Notation of naPool.
        /// </summary>
        /// <returns></returns>

        public static string Notation
        {
            get { return naTools.GetNotation(naPRNG); }
        }

        /// <summary>
        /// Gather entropy.
        /// </summary>
        /// <param name="Data"></param>

        public static void GatherEntropy(int Data)
        {
            lock (_Locker)
            {
                naPRNG.GatherEntropy(Data);
            }
        }

        /// <summary>
        /// Get next random byte.
        /// </summary>
        /// <returns></returns>

        public static byte NextRandomByte()
        {
            lock (_Locker)
            {
                naPRNG.SetNextState();
                return naPRNG.RandomItem;
            }
        }

        /// <summary>
        /// Get next random byte with upper bound.
        /// </summary>
        /// <param name="UpperBound"></param>
        /// <returns></returns>

        public static byte NextRandomByte(byte UpperBound)
        {
            if (UpperBound < 2) return 0;
            byte MultipleUpperBound = (byte)(byte.MaxValue / UpperBound);
            MultipleUpperBound *= UpperBound;

            byte RandomValue = NextRandomByte();
            while (RandomValue >= MultipleUpperBound) RandomValue = NextRandomByte();
            return (byte)(RandomValue % UpperBound);
        }

        /// <summary>
        /// Get next random bytes.
        /// </summary>
        /// <param name="NumberOfBytes"></param>
        /// <returns></returns>

        public static byte[] GetNextRandomBytes(int NumberOfBytes)
        {
            if (NumberOfBytes < 1) return null;
            byte[] NextRandomBytes = new byte[NumberOfBytes];
            for (int Index = 0; Index < NumberOfBytes; Index++) NextRandomBytes[Index] = NextRandomByte();
            return NextRandomBytes;
        }

        /// <summary>
        /// Get next random Int32.
        /// </summary>
        /// <returns></returns>

        public static int NextRandomInt32()
        {
            int RandomValue = BitConverter.ToInt32(GetNextRandomBytes(4), 0);
            while (RandomValue == int.MinValue) RandomValue = BitConverter.ToInt32(GetNextRandomBytes(4), 0);
            return Math.Abs(RandomValue);
        }

        /// <summary>
        /// Get next random Int32 with upper bound.
        /// </summary>
        /// <param name="UpperBound"></param>
        /// <returns></returns>

        public static int NextRandomInt32(int UpperBound)
        {
            if (UpperBound < 2) return 0;
            int MultipleUpperBound = int.MaxValue / UpperBound;
            MultipleUpperBound *= UpperBound;

            int RandomValue = NextRandomInt32();
            while (RandomValue >= MultipleUpperBound) RandomValue = NextRandomInt32();
            return RandomValue % UpperBound;
        }
    }
}
#pragma warning restore