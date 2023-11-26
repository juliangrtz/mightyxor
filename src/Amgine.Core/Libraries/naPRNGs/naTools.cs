// Copyright (C) 1998-2019, Torben Aberspach
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
    /// naTools, non-arithmetic tools.
    /// </summary>
    /// <remarks>
    /// Useful tools and methods for initializing, testing and operating naPRNGs.
    /// </remarks>

    public static class naTools
    {
        /// <summary>
        /// Faculty of n.
        /// </summary>
        /// <param name="n">0 &lt;= n &lt;= 12.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>

        public static int Faculty(int n)
        {
            if (n < 0 || n > 12) throw new ArgumentOutOfRangeException("n: " + n);
            if (n < 2) return 1;
            return n * Faculty(n - 1);
        }

        /// <summary>
        /// True, if Array1 and Array2 are equal with respect to an offset on Array2.
        /// </summary>
        /// <param name="Array1"></param>
        /// <param name="Array2"></param>
        /// <param name="Offset2"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>

        public static bool IsEqual(byte[] Array1, byte[] Array2, int Offset2)
        {
            if (Array1 == null) throw new ArgumentNullException("Array1: null");
            if (Array2 == null) throw new ArgumentNullException("Array2: null");

            if (Array1.Length != Array2.Length) return false;

            for (int Index = 0; Index < Array1.Length; Index++)
            {
                Offset2 %= Array2.Length;
                if (Array1[Index] != Array2[Offset2]) return false;
                Offset2++;
            }
            return true;
        }

        /// <summary>
        /// True, if Array is a permutation.
        /// </summary>
        /// <param name="Array"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>

        public static bool IsPermutation(int[] Array)
        {
            if (Array == null) throw new ArgumentNullException("Array: null");

            bool[] IsElement = new bool[Array.Length];
            for (int Index = 0; Index < Array.Length; Index++) if (Array[Index] < Array.Length) IsElement[Array[Index]] = true;
            for (int Index = 0; Index < Array.Length; Index++) if (!IsElement[Index]) return false;
            return true;
        }

        /// <summary>
        /// Get index of given permutation (alpha-numeric order).
        /// </summary>
        /// <param name="Permutation">2 &lt;= Permutation.Length &lt;= 12</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArrayTypeMismatchException"></exception>

        public static int GetIndexOfPermutation(int[] Permutation)
        {
            if (Permutation == null) throw new ArgumentNullException("Permutation: null");
            if (!IsPermutation(Permutation)) throw new ArrayTypeMismatchException("Permutation: !IsPermutation");
            if (Permutation.Length < 2 || Permutation.Length > 12) throw new ArgumentOutOfRangeException("Permutation.Length: " + Permutation.Length);

            List<int> SetOfElements = new List<int>();
            for (int Index = 0; Index < Permutation.Length; Index++) SetOfElements.Add(Index);

            int IndexOfPermutation = 0;
            for (int Index = 0; Index < Permutation.Length - 1; Index++)
            {
                IndexOfPermutation += SetOfElements.IndexOf(Permutation[Index]);
                SetOfElements.Remove(Permutation[Index]);
                IndexOfPermutation *= SetOfElements.Count;
            }
            return IndexOfPermutation;
        }

        /// <summary>
        /// Get permutation with given index (alpha-numeric order).
        /// </summary>
        /// <param name="NumberOfElements">2 &lt;= NumberOfElements &lt;= 12.</param>
        /// <param name="IndexOfPermutation">0 &lt;= IndexOfPermutation &lt; faculty(NumberOfElements).</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>

        public static int[] GetPermutation(int NumberOfElements, int IndexOfPermutation)
        {
            if (NumberOfElements < 2 || NumberOfElements > 12) throw new ArgumentOutOfRangeException("NumberOfElements: " + NumberOfElements);
            if (IndexOfPermutation < 0 || IndexOfPermutation >= Faculty(NumberOfElements)) throw new ArgumentOutOfRangeException("IndexOfPermutation: " + IndexOfPermutation);

            List<int> SetOfElements = new List<int>();
            for (int Index = 0; Index < NumberOfElements; Index++) SetOfElements.Add((byte)Index);

            int IndexOfElement;
            int[] Permutation = new int[NumberOfElements];

            for (int Index = 0; Index < NumberOfElements; Index++)
            {
                IndexOfElement = Math.DivRem(IndexOfPermutation, Faculty(NumberOfElements - Index - 1), out IndexOfPermutation);
                Permutation[Index] = SetOfElements[IndexOfElement];
                SetOfElements.Remove(Permutation[Index]);
            }
            return Permutation;
        }

        /// <summary>
        /// Get random permutation.
        /// </summary>
        /// <param name="NumberOfElements"></param>
        /// <param name="SystemRND"></param>
        /// <returns></returns>

        public static int[] GetRandomPermutation(int NumberOfElements, Random? SystemRND = null)
        {
            if (NumberOfElements < 1) return null!;

            List<int> SetOfElements = new List<int>();
            for (int Index = 0; Index < NumberOfElements; Index++) SetOfElements.Add(Index);

            int RandomIndex;
            int[] RandomPermutation = new int[NumberOfElements];

            for (int Index = 0; Index < NumberOfElements; Index++)
            {
                RandomIndex = (SystemRND != null) ? SystemRND.Next(NumberOfElements - Index) : naPool.NextRandomInt32(NumberOfElements - Index);
                RandomPermutation[Index] = SetOfElements[RandomIndex];
                SetOfElements.Remove(RandomPermutation[Index]);
            }
            return RandomPermutation;
        }

        /// <summary>
        /// Convert int[] to byte[] using abs and modulo.
        /// </summary>
        /// <param name="IntArray"></param>
        /// <returns></returns>

        public static byte[] ToByteArray(int[] IntArray)
        {
            if (IntArray == null || IntArray.Length < 1) return null!;
            int NumberOfElements = IntArray.Length;

            byte[] ByteArray = new byte[NumberOfElements];
            for (int Index = 0; Index < NumberOfElements; Index++) ByteArray[Index] = (byte)(Math.Abs(IntArray[Index]) % 256);
            return ByteArray;
        }

        /// <summary>
        /// Get identity permutation of integers.
        /// </summary>
        /// <param name="NumberOfElements"></param>
        /// <returns></returns>

        public static int[] GetIdentityIntegers(int NumberOfElements)
        {
            if (NumberOfElements < 1) return null!;

            int[] Identity = new int[NumberOfElements];
            for (int Index = 0; Index < NumberOfElements; Index++) Identity[Index] = Index;
            return Identity;
        }

        /// <summary>
        /// Get identity permutation of bytes.
        /// </summary>
        /// <param name="NumberOfElements"></param>
        /// <returns></returns>

        public static byte[] GetIdentityBytes(int NumberOfElements)
        {
            if (NumberOfElements < 1 || NumberOfElements > 256) return null!;

            byte[] Identity = new byte[NumberOfElements];
            for (int Index = 0; Index < NumberOfElements; Index++) Identity[Index] = (byte)Index;
            return Identity;
        }

        /// <summary>
        /// True, if the items represent the identity permutation.
        /// </summary>
        /// <param name="naPRNG"></param>
        /// <returns></returns>

        public static bool IsStrict(naRND<byte> naPRNG)
        {
            for (int IndexOfSubstitutionBox = 0; IndexOfSubstitutionBox < naPRNG.NumberOfSubstitutionBoxes; IndexOfSubstitutionBox++)
            {
                byte[] Items = naPRNG.GetItems(IndexOfSubstitutionBox);
                for (int IndexOfReference = 0; IndexOfReference < naPRNG.NumberOfReferences; IndexOfReference++)
                {
                    if (Items[IndexOfReference] != IndexOfReference) return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Load state from disk.
        /// </summary>
        /// <param name="FileName"></param>

        public static naRND<byte> Load(string FileName)
        {
            byte[] AdditionalData;
            return Load(FileName, 0, out AdditionalData);
        }

        /// <summary>
        /// Load state and additional data from disk.
        /// </summary>
        /// <param name="FileName"></param>
        /// <param name="NumberOfBytes"></param>
        /// <param name="AdditionalData"></param>
        /// <returns></returns>

        public static naRND<byte> Load(string FileName, int NumberOfBytes, out byte[] AdditionalData)
        {
            try
            {
                AdditionalData = new byte[0];

                FileStream fs = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
                using (BinaryReader r = new BinaryReader(fs))
                {
                    bool IsStrictMode = r.ReadBoolean();
                    int OperationMode = r.ReadInt32();
                    int NumberOfSubstitutionBoxes = r.ReadInt32();
                    int NumberOfReferences = r.ReadInt32();

                    int[][] SubstitutionBoxes = new int[NumberOfSubstitutionBoxes][];
                    for (int Index = 0; Index < NumberOfSubstitutionBoxes; Index++) SubstitutionBoxes[Index] = new int[NumberOfReferences];

                    byte[][] ItemBoxes = new byte[NumberOfSubstitutionBoxes][];
                    for (int Index = 0; Index < NumberOfSubstitutionBoxes; Index++) ItemBoxes[Index] = new byte[NumberOfReferences];

                    for (int IndexOfSubstitutionBox = 0; IndexOfSubstitutionBox < NumberOfSubstitutionBoxes; IndexOfSubstitutionBox++)
                    {
                        if (IsStrictMode) ItemBoxes[IndexOfSubstitutionBox] = GetIdentityBytes(NumberOfReferences);
                        else ItemBoxes[IndexOfSubstitutionBox] = r.ReadBytes(NumberOfReferences);
                        {
                            for (int IndexOfReference = 0; IndexOfReference < NumberOfReferences; IndexOfReference++)
                            {
                                if (IsStrictMode) SubstitutionBoxes[IndexOfSubstitutionBox][IndexOfReference] = r.ReadByte();
                                else SubstitutionBoxes[IndexOfSubstitutionBox][IndexOfReference] = r.ReadInt32();
                            }
                        }
                    }

                    int SubstitutionBoxIterator = r.ReadInt32();
                    int ReferenceIterator = r.ReadInt32();
                    int LastReference = r.ReadInt32();

                    if (NumberOfBytes > 0) AdditionalData = r.ReadBytes(NumberOfBytes);
                    return new naRND<byte>((OperationModes)OperationMode, ItemBoxes, SubstitutionBoxes, SubstitutionBoxIterator, ReferenceIterator, LastReference);
                }
            }
            finally
            {
            }
        }

        /// <summary>
        /// Save state to disk.
        /// </summary>
        /// <param name="naPRNG"></param>
        /// <param name="FileName"></param>
        /// <param name="AdditionalData"></param>

        public static void Save(naRND<byte> naPRNG, string FileName, byte[]? AdditionalData = null)
        {
            try
            {
                FileStream fs = new FileStream(FileName, FileMode.Create, FileAccess.Write, FileShare.None);
                using (BinaryWriter w = new BinaryWriter(fs))
                {
                    w.Write(IsStrict(naPRNG));
                    w.Write((int)naPRNG.OperationMode);
                    w.Write(naPRNG.NumberOfSubstitutionBoxes);
                    w.Write(naPRNG.NumberOfReferences);

                    for (int IndexOfSubstitutionBox = 0; IndexOfSubstitutionBox < naPRNG.NumberOfSubstitutionBoxes; IndexOfSubstitutionBox++)
                    {
                        if (!IsStrict(naPRNG))
                        {
                            byte[] Items = naPRNG.GetItems(IndexOfSubstitutionBox);
                            w.Write(Items);
                        }
                        int[] SubstitutionBox = naPRNG.GetSubstitutionBox(IndexOfSubstitutionBox);
                        for (int IndexOfReference = 0; IndexOfReference < naPRNG.NumberOfReferences; IndexOfReference++)
                        {
                            if (IsStrict(naPRNG)) w.Write((byte)SubstitutionBox[IndexOfReference]);
                            else w.Write(SubstitutionBox[IndexOfReference]);
                        }
                    }

                    w.Write(naPRNG.SubstitutionBoxIterator);
                    w.Write(naPRNG.ReferenceIterator);
                    w.Write(naPRNG.LastReference);

                    if (AdditionalData != null) w.Write(AdditionalData);
                }
            }
            finally
            {
            }
        }

        /// <summary>
        /// Get the notation for the given naPRNG.
        /// </summary>
        /// <param name="naPRNG"></param>
        /// <returns></returns>

        public static string GetNotation(naRND<byte> naPRNG)
        {
            naRND<byte>[] naPRNGs = new naRND<byte>[1];
            naPRNGs[0] = naPRNG;
            return GetNotation(naPRNGs);
        }

        /// <summary>
        /// Get the notation for multiple naPRNGs.
        /// </summary>
        /// <param name="naPRNGs"></param>
        /// <returns></returns>

        public static string GetNotation(naRND<byte>[] naPRNGs)
        {
            string Notation = "naRND";
            foreach (naRND<byte> naPRNG in naPRNGs)
            {
                Notation += " [" + naPRNG.OperationMode;
                Notation += (IsStrict(naPRNG)) ? ", Strict] " : ", Loose] ";
                Notation += "[" + naPRNG.NumberOfSubstitutionBoxes;
                Notation += ", " + naPRNG.NumberOfReferences + "]";
            }
            return Notation;
        }

        /// <summary>
        /// Get the visualization for the given naPRNG.
        /// </summary>
        /// <param name="naPRNG"></param>
        /// <returns></returns>

        public static string GetVisualization(naRND<byte> naPRNG)
        {
            naRND<byte>[] naPRNGs = new naRND<byte>[1];
            naPRNGs[0] = naPRNG;
            return GetVisualization(naPRNGs);
        }

        /// <summary>
        /// Get the visualization for multiple naPRNGs.
        /// </summary>
        /// <param name="naPRNGs"></param>
        /// <returns></returns>

        public static string GetVisualization(naRND<byte>[] naPRNGs)
        {
            string Visualization = "";
            foreach (naRND<byte> naPRNG in naPRNGs)
            {
                for (int IndexOfSubstitutionBox = 0; IndexOfSubstitutionBox < naPRNG.NumberOfSubstitutionBoxes; IndexOfSubstitutionBox++)
                {
                    byte[] ReferencedItems = naPRNG.GetReferencedItems(IndexOfSubstitutionBox);
                    if (IndexOfSubstitutionBox == naPRNG.SubstitutionBoxIterator) Visualization += "S";
                    for (int IndexOfReference = 0; IndexOfReference < naPRNG.NumberOfReferences; IndexOfReference++)
                    {
                        Visualization += "\t" + ReferencedItems[IndexOfReference];
                    }
                    Visualization += Environment.NewLine;
                }

                for (int Index = 0; Index < naPRNG.NumberOfReferences; Index++)
                {
                    Visualization += "\t";
                    if (Index == naPRNG.ReferenceIterator) Visualization += "R";
                    if (Index == naPRNG.LastReference) Visualization += "L";
                }
                Visualization += Environment.NewLine;
            }
            return Visualization;
        }
    }
}
#pragma warning restore