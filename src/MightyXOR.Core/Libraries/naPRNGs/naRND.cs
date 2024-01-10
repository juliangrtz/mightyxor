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
namespace MightyXOR.Core.Libraries.naPRNGs
{
    /// <summary>
    /// Predefined operation modes.
    /// </summary>
    /// <remarks>
    /// The second version operation mode was developed later, hence the names.
    /// </remarks>

    public enum OperationModes
    {
        /// <summary>
        /// First version of naPRNGs.
        /// </summary>
        V1 = 1,

        /// <summary>
        /// Second version of naPRNGs.
        /// </summary>
        V2 = 2
    }

    /// <summary>
    /// naRND, non-arithmetic random.
    /// </summary>
    /// <remarks>
    /// A generic prototype providing functionality to initialize and run naPRNGs.
    /// </remarks>

    public class naRND<T>
    {
        /// <summary>
        /// Operation mode.
        /// </summary>

        public readonly OperationModes OperationMode;

        /// <summary>
        /// Predefined values for number of substitution boxes.
        /// </summary>
        /// <remarks>
        /// Maximum and default values are chosen by consideration.
        /// It is recommended to use at least two substitution boxes for first version naPRNGs.
        /// </remarks>

        public const int
            MinimumNumberOfSubstitutionBoxes = 1,
            MaximumNumberOfSubstitutionBoxes = 16,
            DefaultNumberOfSubstitutionBoxes = 4;

        /// <summary>
        /// Predefined values for number of references.
        /// </summary>
        /// <remarks>
        /// Maximum and default values are chosen by consideration.
        /// </remarks>

        public const int
            MinimumNumberOfReferences = 2,
            MaximumNumberOfReferences = 65536,
            DefaultNumberOfReferences = 256;

        /// <summary>
        /// Number of substitution boxes.
        /// </summary>

        public readonly int NumberOfSubstitutionBoxes;

        /// <summary>
        /// Number of references.
        /// </summary>

        public readonly int NumberOfReferences;

        /// <summary>
        /// Provides functionality to access any node directly.
        /// </summary>
        /// <remarks>
        /// QuickReference is not necessary for basic functionality.
        /// If using naPRNGs based on arrays, this is obsolete anyway.
        /// </remarks>

        private naNode[,] QuickReference;

        /// <summary>
        /// non-arithmetic node.
        /// </summary>
        /// <remarks>
        /// The members SubstitutionBoxIndex, ReferenceIndex and Previous are not necessary for basic functionality.
        /// </remarks>

        private class naNode
        {
            public int SubstitutionBoxIndex;
            public int ReferenceIndex;
            public naNode Previous;
            public naNode Next;
            public naNode Reference;
            public T Item;
        }

        /// <summary>
        /// Private members.
        /// </summary>

        private readonly int TotalNumberOfNodes;

        private naNode
            Base,
            Iterator,
            Last;

        /// <summary>
        /// Create a new instance of naRND.
        /// </summary>
        /// <param name="OperationMode">Operation mode.</param>
        /// <param name="ItemBoxes">ItemBoxes[NumberOfSubstitutionBoxes][NumberOfReferences], same dimensions as SubstitutionBoxes.</param>
        /// <param name="SubstitutionBoxes">SubstitutionBoxes[NumberOfSubstitutionBoxes][NumberOfReferences], MinimumNumberOfSubstitutionBoxes &lt;= NumberOfSubstitutionBoxes &lt;= MaximumNumberOfSubstitutionBoxes and MinimumNumberOfReferences &lt;= NumberOfReferences &lt;= MaximumNumberOfReferences.</param>
        /// <param name="SubstitutionBoxIterator">0 &lt;= SubstitutionBoxIterator &lt; NumberOfSubstitutionBoxes.</param>
        /// <param name="ReferenceIterator">0 &lt;= ReferenceIterator &lt; NumberOfReferences.</param>
        /// <param name="LastReference">0 &lt;= LastReference &lt; NumberOfReferences.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArrayTypeMismatchException"></exception>

        public naRND(OperationModes OperationMode, T[][] ItemBoxes, int[]?[] SubstitutionBoxes, int SubstitutionBoxIterator, int ReferenceIterator, int LastReference)
        {
            this.OperationMode = OperationMode;
            NumberOfSubstitutionBoxes = SubstitutionBoxes.Length;
            NumberOfReferences = SubstitutionBoxes[0].Length;
            TotalNumberOfNodes = NumberOfSubstitutionBoxes * NumberOfReferences;

            if (NumberOfSubstitutionBoxes < MinimumNumberOfSubstitutionBoxes || NumberOfSubstitutionBoxes > MaximumNumberOfSubstitutionBoxes) throw new ArgumentOutOfRangeException("NumberOfSubstitutionBoxes: " + NumberOfSubstitutionBoxes);
            if (NumberOfReferences < MinimumNumberOfReferences || NumberOfReferences > MaximumNumberOfReferences) throw new ArgumentOutOfRangeException("NumberOfReferences: " + NumberOfReferences);

            foreach (int[]? SubstitutionBox in SubstitutionBoxes) if (SubstitutionBox.Length != NumberOfReferences) throw new ArrayTypeMismatchException("SubstitutionBoxes[].Length: " + SubstitutionBox.Length);
            foreach (int[]? SubstitutionBox in SubstitutionBoxes) if (!naTools.IsPermutation(SubstitutionBox)) throw new ArrayTypeMismatchException("SubstitutionBoxes[]: !IsPermutation");

            if (ItemBoxes.Length != NumberOfSubstitutionBoxes) throw new ArrayTypeMismatchException("ItemBoxes.Length: " + ItemBoxes.Length);
            foreach (T[] ItemBox in ItemBoxes) if (ItemBox.Length != NumberOfReferences) throw new ArrayTypeMismatchException("ItemBoxes[].Length: " + ItemBox.Length);

            if (SubstitutionBoxIterator < 0 || SubstitutionBoxIterator >= NumberOfSubstitutionBoxes) throw new ArgumentOutOfRangeException("SubstitutionBoxIterator: " + SubstitutionBoxIterator);
            if (ReferenceIterator < 0 || ReferenceIterator >= NumberOfReferences) throw new ArgumentOutOfRangeException("ReferenceIterator: " + ReferenceIterator);
            if (LastReference < 0 || LastReference >= NumberOfReferences) throw new ArgumentOutOfRangeException("LastReference: " + LastReference);

            Base = CreateBasicStructure();

            // Set the references and items per node.
            naNode Node = Base;
            for (int IndexOfReference = 0; IndexOfReference < NumberOfReferences; IndexOfReference++)
            {
                for (int IndexOfSubstitutionBox = 0; IndexOfSubstitutionBox < NumberOfSubstitutionBoxes; IndexOfSubstitutionBox++)
                {
                    int ReferencedIndex = SubstitutionBoxes[IndexOfSubstitutionBox][IndexOfReference];
                    Node.Reference = QuickReference[(IndexOfSubstitutionBox + 1) % NumberOfSubstitutionBoxes, ReferencedIndex];
                    Node.Reference.Item = ItemBoxes[IndexOfSubstitutionBox][ReferencedIndex];
                    Node = Node.Next;
                }
            }

            // Set nodes Iterator and Last.
            Iterator = QuickReference[SubstitutionBoxIterator, ReferenceIterator];
            Last = QuickReference[SubstitutionBoxIterator, LastReference];

            // If first version operation mode, set Last to its valid state.
            if (OperationMode == OperationModes.V1)
            {
                Last = Iterator.Previous;
                Last = Last.Reference;
            }
        }

        /// <summary>
        /// Create a new instance of naRND as a deep clone of the given naPRNG.
        /// </summary>
        /// <param name="naPRNG"></param>

        private naRND(naRND<T> naPRNG)
        {
            OperationMode = naPRNG.OperationMode;
            NumberOfSubstitutionBoxes = naPRNG.NumberOfSubstitutionBoxes;
            NumberOfReferences = naPRNG.NumberOfReferences;
            TotalNumberOfNodes = NumberOfSubstitutionBoxes * NumberOfReferences;

            Base = CreateBasicStructure();

            // Set the references and items per node.
            naNode Node = Base;
            naNode External = naPRNG.Base;
            for (int IndexOfReference = 0; IndexOfReference < NumberOfReferences; IndexOfReference++)
            {
                for (int IndexOfSubstitutionBox = 0; IndexOfSubstitutionBox < NumberOfSubstitutionBoxes; IndexOfSubstitutionBox++)
                {
                    Node.Reference = QuickReference[External.Reference.SubstitutionBoxIndex, External.Reference.ReferenceIndex];
                    Node.Item = External.Item;
                    External = External.Next;
                    Node = Node.Next;
                }
            }

            // Set nodes Iterator and Last.
            Iterator = QuickReference[naPRNG.SubstitutionBoxIterator, naPRNG.ReferenceIterator];
            Last = QuickReference[naPRNG.SubstitutionBoxIterator, naPRNG.LastReference];
        }

        /// <summary>
        /// Create the basic structure for naPRNGs.
        /// </summary>
        /// <returns></returns>

        private naNode CreateBasicStructure()
        {
            QuickReference = new naNode[NumberOfSubstitutionBoxes, NumberOfReferences];
            naNode Base = new naNode();
            naNode Node = Base;

            for (int IndexOfReference = 0; IndexOfReference < NumberOfReferences; IndexOfReference++)
            {
                for (int IndexOfSubstitutionBox = 0; IndexOfSubstitutionBox < NumberOfSubstitutionBoxes; IndexOfSubstitutionBox++)
                {
                    if (IndexOfReference == NumberOfReferences - 1 && IndexOfSubstitutionBox == NumberOfSubstitutionBoxes - 1) Node.Next = Base;
                    else Node.Next = new naNode();
                    Node.Next.Previous = Node;
                    Node.SubstitutionBoxIndex = IndexOfSubstitutionBox;
                    Node.ReferenceIndex = IndexOfReference;
                    QuickReference[IndexOfSubstitutionBox, IndexOfReference] = Node;
                    Node = Node.Next;
                }
            }
            return Base;
        }

        /// <summary>
        /// Create a deep clone.
        /// </summary>
        /// <returns></returns>

        public naRND<T> DeepClone()
        {
            naRND<T> DeepClone = new naRND<T>(this);
            return DeepClone;
        }

        /// <summary>
        /// Set the node Last to a new position within the same substitution box.
        /// </summary>
        /// <param name="IndexOfReference"></param>

        internal void SetLastReference(int IndexOfReference)
        {
            IndexOfReference = Math.Abs(IndexOfReference) % NumberOfReferences;
            Last = QuickReference[SubstitutionBoxIterator, IndexOfReference];
        }

        /// <summary>
        /// Gather entropy.
        /// </summary>
        /// <param name="Data"></param>

        public void GatherEntropy(int Data)
        {
            Data = Math.Abs(Data % NumberOfReferences) + LastReference;
            SetLastReference(Data);
            for (int Counter = 0; Counter <= Data; Counter++) SetNextState();
        }

        /// <summary>
        /// Gather entropy.
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="Repeat"></param>

        public void GatherEntropy(int Data, byte Repeat = 0)
        {
            for (int Counter = 0; Counter <= Repeat; Counter++) GatherEntropy(Data + Counter);
        }

        /// <summary>
        /// Get the item referenced by the node with the given indices for substitution box and reference.
        /// </summary>
        /// <param name="IndexOfSubstitutionBox"></param>
        /// <param name="IndexOfReference"></param>
        /// <returns></returns>

        internal T GetReferencedItem(int IndexOfSubstitutionBox, int IndexOfReference)
        {
            return QuickReference[IndexOfSubstitutionBox, IndexOfReference].Reference.Item;
        }

        /// <summary>
        /// Get the items of the substitution box with the given index in original order.
        /// </summary>
        /// <param name="IndexOfSubstitutionBox"></param>
        /// <returns></returns>

        internal T[] GetItems(int IndexOfSubstitutionBox)
        {
            T[] Items = new T[NumberOfReferences];
            for (int IndexOfReference = 0; IndexOfReference < NumberOfReferences; IndexOfReference++)
            {
                int ReferencedIndex = QuickReference[IndexOfSubstitutionBox, IndexOfReference].Reference.ReferenceIndex;
                Items[ReferencedIndex] = QuickReference[IndexOfSubstitutionBox, IndexOfReference].Reference.Item;
            }
            return Items;
        }

        /// <summary>
        /// Get the items of the substitution box with the given index in referenced order.
        /// </summary>
        /// <param name="IndexOfSubstitutionBox"></param>
        /// <returns></returns>

        internal T[] GetReferencedItems(int IndexOfSubstitutionBox)
        {
            T[] ReferencedItems = new T[NumberOfReferences];
            for (int IndexOfReference = 0; IndexOfReference < NumberOfReferences; IndexOfReference++)
            {
                ReferencedItems[IndexOfReference] = QuickReference[IndexOfSubstitutionBox, IndexOfReference].Reference.Item;
            }
            return ReferencedItems;
        }

        /// <summary>
        /// Get the substitution box with the given index.
        /// </summary>
        /// <returns></returns>

        internal int[] GetSubstitutionBox(int IndexOfSubstitutionBox)
        {
            int[] SubstitutionBox = new int[NumberOfReferences];
            for (int IndexOfReference = 0; IndexOfReference < NumberOfReferences; IndexOfReference++)
            {
                SubstitutionBox[IndexOfReference] = QuickReference[IndexOfSubstitutionBox, IndexOfReference].Reference.ReferenceIndex;
            }
            return SubstitutionBox;
        }

        /// <summary>
        /// True, if all substitution boxes represent the same permutation.
        /// </summary>
        /// <returns></returns>

        internal bool IsIsoState()
        {
            if (NumberOfSubstitutionBoxes == 1) return true;
            naNode Node = Base;

            for (int IndexOfReference = 0; IndexOfReference < NumberOfReferences; IndexOfReference++)
            {
                for (int IndexOfSubstitutionBox = 1; IndexOfSubstitutionBox < NumberOfSubstitutionBoxes; IndexOfSubstitutionBox++)
                {
                    if (Node.Reference.ReferenceIndex != Node.Next.Reference.ReferenceIndex) return false;
                    Node = Node.Next;
                }
                Node = Node.Next;
            }
            return true;
        }

        /// <summary>
        /// True, if the current naPRNG is equal to the given naPRNG due to the state of the substitution boxes.
        /// </summary>
        /// <param name="naPRNG"></param>
        /// <returns></returns>

        internal bool IsEqualTo(naRND<T> naPRNG)
        {
            if (Iterator.SubstitutionBoxIndex != naPRNG.Iterator.SubstitutionBoxIndex) return false;
            if (Iterator.ReferenceIndex != naPRNG.Iterator.ReferenceIndex) return false;
            if (Last.ReferenceIndex != naPRNG.Last.ReferenceIndex) return false;

            naNode Node = Base;
            naNode External = naPRNG.Base;
            for (int Index = 0; Index < TotalNumberOfNodes; Index++)
            {
                if (Node.Reference.ReferenceIndex != External.Reference.ReferenceIndex) return false;
                Node = Node.Next;
                External = External.Next;
            }
            return true;
        }

        /// <summary>
        /// Index of substitution box of node Iterator.
        /// </summary>

        internal int SubstitutionBoxIterator
        {
            get { return Iterator.SubstitutionBoxIndex; }
        }

        /// <summary>
        /// Index of reference of node Iterator.
        /// </summary>

        internal int ReferenceIterator
        {
            get { return Iterator.ReferenceIndex; }
        }

        /// <summary>
        /// Index of reference of node Last.
        /// </summary>

        internal int LastReference
        {
            get { return Last.ReferenceIndex; }
        }

        /// <summary>
        /// Current referenced item of node Last.
        /// </summary>

        internal T LastItem
        {
            get { return Last.Reference.Item; }
        }

        /// <summary>
        /// Current referenced item of node Iterator.
        /// </summary>

        internal T IteratorItem
        {
            get { return Iterator.Reference.Item; }
        }

        /// <summary>
        /// Current random item.
        /// </summary>

        public T RandomItem
        {
            get
            {
                if (OperationMode == OperationModes.V1) return IteratorItem;
                return LastItem;
            }
        }

        /// <summary>
        /// Set the generator to the previous state.
        /// </summary>
        /// <exception cref="NotSupportedException"></exception>

        public void SetPreviousState()
        {
            if (OperationMode == OperationModes.V1 && NumberOfSubstitutionBoxes == 1) throw new NotSupportedException("OperationMode: V1, NumberOfSubstitutionBoxes: 1");

            Iterator = Iterator.Previous;
            if (OperationMode == OperationModes.V1) naCore_V1_Reverse();
            else naCore_V2_Reverse();
        }

        /// <summary>
        /// Set the generator to the next state.
        /// </summary>

        public void SetNextState()
        {
            if (OperationMode == OperationModes.V1) naCore_V1();
            else naCore_V2();
            Iterator = Iterator.Next;
        }

        /// <summary>
        /// Core function for first version generators.
        /// </summary>

        private void naCore_V1()
        {
            naNode Swap = Last.Reference;
            Last.Reference = Iterator.Reference;
            Iterator.Reference = Swap;
            Last = Swap;
        }

        /// <summary>
        /// Core function for second version generators.
        /// </summary>

        private void naCore_V2()
        {
            naNode Swap = Iterator.Reference;
            Iterator.Reference = Last.Reference;
            Last.Reference = Swap;
            Last = Swap;
        }

        /// <summary>
        /// Core function for first version generators, reverse mode.
        /// </summary>

        private void naCore_V1_Reverse()
        {
            Last = Iterator.Previous;
            Last = Last.Reference;

            naNode Swap = Last.Reference;
            Last.Reference = Iterator.Reference;
            Iterator.Reference = Swap;
        }

        /// <summary>
        /// Core function for second version generators, reverse mode.
        /// </summary>

        private void naCore_V2_Reverse()
        {
            naNode Node = Last;
            while (Last.Reference != Node) Last = Last.Next;

            naNode Swap = Iterator.Reference;
            Iterator.Reference = Last.Reference;
            Last.Reference = Swap;
        }
    }
}
#pragma warning restore