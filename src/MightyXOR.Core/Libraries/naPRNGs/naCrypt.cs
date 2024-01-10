// Copyright (C) 2010-2019, Torben Aberspach
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
    /// Predefined security levels.
    /// </summary>

    public enum SecurityLevels
    {
        /// <summary>
        /// Low security level using 1 substitution box.
        /// </summary>
        Low = 1,

        /// <summary>
        /// Middle security level using 4 substitution boxes.
        /// </summary>
        Mid = 4,

        /// <summary>
        /// High security level using 16 substitution boxes.
        /// </summary>
        High = 16
    }

    /// <summary>
    /// Predefined states for decryption errors.
    /// </summary>

    public enum InconsistentDataErrors
    {
        /// <summary>
        /// No inconsistent data found.
        /// </summary>
        None,

        /// <summary>
        /// Inconsistent data found and presumably repaired.
        /// </summary>
        Repaired,

        /// <summary>
        /// Inconsistent data found and not repaired.
        /// </summary>
        Resists
    }

    /// <summary>
    /// naCrypt, non-arithmetic encryption.
    /// </summary>
    /// <remarks>
    /// Whilst naCrypt is not totally non-arithmetic, the name refers to the use of naPRNGs.
    /// </remarks>

    public class naCrypt
    {
        /// <summary>
        /// Latest modification date.
        /// </summary>

        public const string Version = "Latest algorithm modification: January 2019";

        /// <summary>
        /// Default file extension.
        /// </summary>

        public const string FileExtension = ".nakey";

        /// <summary>
        /// Default operation mode.
        /// </summary>

        public const OperationModes OperationMode = OperationModes.V2;

        /// <summary>
        /// Indicates if inconsistent data was found.
        /// </summary>

        public InconsistentDataErrors InconsistentDataError = InconsistentDataErrors.None;

        /// <summary>
        /// Default crypted small data block length.
        /// </summary>

        private const int CryptSmallDataBlockLength = 256;

        /// <summary>
        /// Default crypted big data block length.
        /// </summary>

        public const int CryptBigDataBlockLength = 65536;

        /// <summary>
        /// Default plain small data block length.
        /// Depends on high reliability.
        /// </summary>

        private int PlainSmallDataBlockLength
        {
            get { return (HighReliability) ? 127 : 256; }
        }

        /// <summary>
        /// Default plain big data block length.
        /// Depends on high reliability.
        /// </summary>

        public int PlainBigDataBlockLength
        {
            get { return PlainSmallDataBlockLength * 256; }
        }

        /// <summary>
        /// True, if high reliability is used.
        /// </summary>

        public readonly bool HighReliability;

        /// <summary>
        /// Private members.
        /// </summary>

        private naRND<byte>? naPRNG;
        private byte[] EncryptionKey;
        private int Feedback;

        /// <summary>
        /// Create a new instance of naCrypt.
        /// </summary>
        /// <param name="SecurityLevel"></param>
        /// <param name="HighReliability"></param>

        public naCrypt(SecurityLevels SecurityLevel, bool HighReliability)
        {
            this.HighReliability = HighReliability;
            Initialize((int)SecurityLevel, 256);
        }

        /// <summary>
        /// Create a new instance of naCrypt from disk.
        /// </summary>
        /// <param name="FileName"></param>
        /// <exception cref="NotSupportedException"></exception>

        public naCrypt(string FileName)
        {
            if (!FileName.EndsWith(FileExtension)) throw new NotSupportedException("FileType: Extension");
            byte[] Configuration = new byte[0];
            naPRNG = naTools.Load(FileName, 1, out Configuration);
            if (!IsValidState(naPRNG)) throw new NotSupportedException("FileType: !IsValidState");
            HighReliability = BitConverter.ToBoolean(Configuration, 0);
        }

        /// <summary>
        /// Initialize by random seed.
        /// </summary>
        /// <param name="NumberOfSubstitutionBoxes">MinimumNumberOfSubstitutionBoxes &lt;= NumberOfSubstitutionBoxes &lt;= MaximumNumberOfSubstitutionBoxes.</param>
        /// <param name="NumberOfReferences">MinimumNumberOfReferences &lt;= NumberOfReferences &lt;= MaximumNumberOfReferences.</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>

        private void Initialize(int NumberOfSubstitutionBoxes, int NumberOfReferences)
        {
            if (NumberOfSubstitutionBoxes < naRND<byte>.MinimumNumberOfSubstitutionBoxes || NumberOfSubstitutionBoxes > naRND<byte>.MaximumNumberOfSubstitutionBoxes) throw new ArgumentOutOfRangeException("NumberOfSubstitutionBoxes: " + NumberOfSubstitutionBoxes);
            if (NumberOfReferences < naRND<byte>.MinimumNumberOfReferences || NumberOfReferences > naRND<byte>.MaximumNumberOfReferences) throw new ArgumentOutOfRangeException("NumberOfReferences: " + NumberOfReferences);

            int[]?[] SubstitutionBoxes = new int[NumberOfSubstitutionBoxes][];
            for (int Index = 0; Index < NumberOfSubstitutionBoxes; Index++) SubstitutionBoxes[Index] = naTools.GetRandomPermutation(NumberOfReferences);

            byte[][] ItemBoxes = new byte[NumberOfSubstitutionBoxes][];
            for (int Index = 0; Index < NumberOfSubstitutionBoxes; Index++) ItemBoxes[Index] = naTools.GetIdentityBytes(NumberOfReferences);

            int SubstitutionBoxIterator = naPool.NextRandomInt32(NumberOfSubstitutionBoxes);
            int ReferenceIterator = naPool.NextRandomInt32(NumberOfReferences);
            int LastReference = naPool.NextRandomInt32(NumberOfReferences);

            naPRNG = new naRND<byte>(OperationMode, ItemBoxes, SubstitutionBoxes, SubstitutionBoxIterator, ReferenceIterator, LastReference);
        }

        /// <summary>
        /// Check naPRNG for internal restrictions.
        /// </summary>
        /// <param name="naPRNG"></param>
        /// <returns></returns>

        private bool IsValidState(naRND<byte>? naPRNG)
        {
            if (naPRNG.OperationMode != OperationMode || !naTools.IsStrict(naPRNG)) return false;
            if (naPRNG.NumberOfReferences != 256 || (int)SecurityLevel != naPRNG.NumberOfSubstitutionBoxes) return false;
            return true;
        }

        /// <summary>
        /// Save state to disk.
        /// </summary>
        /// <param name="FileName"></param>

        public void Save(string FileName)
        {
            byte[]? Configuration = new byte[1];
            Configuration[0] = BitConverter.GetBytes(HighReliability)[0];
            if (!FileName.EndsWith(FileExtension)) FileName += FileExtension;
            naTools.Save(naPRNG, FileName, Configuration);
        }

        /// <summary>
        /// Set password.
        /// </summary>

        public byte[] Password
        {
            set
            {
                EncryptionKey = value;
                foreach (byte Key in EncryptionKey) naPRNG.GatherEntropy(Key);

                int Length = EncryptionKey.Length;
                Array.Resize(ref EncryptionKey, CryptSmallDataBlockLength);
                for (int Index = Length; Index < CryptSmallDataBlockLength; Index++) EncryptionKey[Index] = Encrypt((byte)Index, false);

                for (int Index = 0; Index < EncryptionKey.Length; Index++) EncryptionKey[Index] = Encrypt(EncryptionKey[Index], false);
            }
        }

        /// <summary>
        /// Security level.
        /// </summary>

        public SecurityLevels SecurityLevel
        {
            get { return (SecurityLevels)naPRNG.NumberOfSubstitutionBoxes; }
        }

        /// <summary>
        /// Get data length after encryption.
        /// </summary>
        /// <param name="PlainLength"></param>
        /// <returns></returns>

        public long GetEncryptedLength(long PlainLength)
        {
            long EncryptedLength = PlainLength;
            if (HighReliability) EncryptedLength = EncryptedLength * CryptSmallDataBlockLength / PlainSmallDataBlockLength;
            EncryptedLength = EncryptedLength + CryptSmallDataBlockLength - EncryptedLength % CryptSmallDataBlockLength;
            return EncryptedLength;
        }

        /// <summary>
        /// Get the number of plain data blocks.
        /// </summary>
        /// <param name="PlainLength"></param>
        /// <returns></returns>

        public int GetPlainDataBlocks(long PlainLength)
        {
            int PlainDataBlocks = (int)(PlainLength / PlainBigDataBlockLength);
            if (PlainLength % PlainBigDataBlockLength != 0) PlainDataBlocks++;
            return PlainDataBlocks;
        }

        /// <summary>
        /// Get the number of encrypted data blocks.
        /// </summary>
        /// <param name="EncryptedLength"></param>
        /// <returns></returns>

        public int GetCryptDataBlocks(long EncryptedLength)
        {
            int CryptDataBlocks = (int)(EncryptedLength / CryptBigDataBlockLength);
            if (EncryptedLength % CryptBigDataBlockLength != 0) CryptDataBlocks++;
            return CryptDataBlocks;
        }

        /// <summary>
        /// Current secure random value.
        /// </summary>

        private int CurrentSecureValue
        {
            get { return naPRNG.IteratorItem ^ naPRNG.LastItem; }
        }

        /// <summary>
        /// Get feedback value, reverse mode.
        /// Used in high reliability mode when inconsistent data was found.
        /// </summary>
        /// <param name="Cipher"></param>
        /// <returns></returns>

        private int GetPreviousFeedback(byte Cipher)
        {
            byte[] ReferencedItems = naPRNG.GetReferencedItems(naPRNG.SubstitutionBoxIterator);
            Feedback = ReferencedItems[Cipher] ^ Feedback;
            return Array.IndexOf(ReferencedItems, (byte)Feedback);
        }

        /// <summary>
        /// Get feedback value.
        /// Used in high reliability mode.
        /// </summary>
        /// <param name="Cipher"></param>
        /// <returns></returns>

        private int GetFeedback(byte Cipher)
        {
            int SBox = naPRNG.SubstitutionBoxIterator;
            return naPRNG.GetReferencedItem(SBox, Feedback) ^ naPRNG.GetReferencedItem(SBox, Cipher);
        }

        /// <summary>
        /// Reset feedback to prevent cascading errors.
        /// </summary>

        private void ResetFeedback()
        {
            Feedback = CurrentSecureValue;
            naPRNG.SetNextState();
        }

        /// <summary>
        /// Create a substitution box of given length.
        /// </summary>
        /// <param name="Length"></param>
        /// <returns></returns>

        private byte[] GetSubstitutionBox(int Length)
        {
            byte[] SubstitutionBox = naPRNG.GetReferencedItems(naPRNG.SubstitutionBoxIterator);
            if (Length == naPRNG.NumberOfReferences) return SubstitutionBox;

            int IndexOfCandidate = 0;
            for (int Index = 0; Index < Length; Index++)
            {
                while (SubstitutionBox[IndexOfCandidate] >= Length) IndexOfCandidate++;
                SubstitutionBox[Index] = SubstitutionBox[IndexOfCandidate++];
            }
            Array.Resize(ref SubstitutionBox, Length);
            return SubstitutionBox;
        }

        /// <summary>
        /// Duplicate small data block.
        /// Last pair is chosen by random.
        /// </summary>
        /// <param name="SmallDataBlock"></param>
        /// <returns></returns>

        private byte[] Duplicate(byte[] SmallDataBlock)
        {
            Array.Resize(ref SmallDataBlock, SmallDataBlock.Length * 2 + 2);
            SmallDataBlock[SmallDataBlock.Length / 2 - 1] = naPool.NextRandomByte();
            for (int Index = SmallDataBlock.Length - 1; Index > 0; Index--) SmallDataBlock[Index] = SmallDataBlock[Index / 2];
            return SmallDataBlock;
        }

        /// <summary>
        /// Encrypt a single byte.
        /// </summary>
        /// <param name="Plain"></param>
        /// <param name="HighReliability"></param>
        /// <returns></returns>

        private byte Encrypt(byte Plain, bool HighReliability)
        {
            byte Cipher = (byte)(Plain ^ CurrentSecureValue);
            if (HighReliability)
            {
                Cipher = (byte)(Cipher ^ Feedback);
                Feedback = GetFeedback(Cipher);
            }
            naPRNG.SetNextState();
            return Cipher;
        }

        /// <summary>
        /// Encrypt small data block with transposition of its elements.
        /// </summary>
        /// <param name="SmallDataBlock"></param>
        /// <returns></returns>

        private byte[] EncryptSmallDataBlock(byte[] SmallDataBlock)
        {
            byte[] Encrypted = new byte[CryptSmallDataBlockLength];
            byte[] SubstitutionBox = GetSubstitutionBox(CryptSmallDataBlockLength);

            if (HighReliability)
            {
                SmallDataBlock = Duplicate(SmallDataBlock);
                ResetFeedback();
            }

            for (int Index = 0; Index < CryptSmallDataBlockLength; Index++)
            {
                Encrypted[SubstitutionBox[Index]] = Encrypt(SmallDataBlock[Index], HighReliability);
                if (!HighReliability) EncryptionKey[Index] = (byte)(EncryptionKey[Index] ^ Encrypted[SubstitutionBox[Index]]);
            }
            return Encrypted;
        }

        /// <summary>
        /// Encrypt big data block with transposition of its small data blocks.
        /// </summary>
        /// <param name="BigDataBlock"></param>
        /// <returns></returns>

        private byte[] EncryptBigDataBlock(byte[] BigDataBlock)
        {
            byte[] SmallDataBlock = new byte[PlainSmallDataBlockLength];
            int NumberOfBlocks = BigDataBlock.Length / PlainSmallDataBlockLength;

            byte[] Encrypted = new byte[CryptSmallDataBlockLength * NumberOfBlocks];
            byte[] SubstitutionBox = GetSubstitutionBox(NumberOfBlocks);

            for (int Index = 0; Index < NumberOfBlocks; Index++)
            {
                naPRNG.GatherEntropy(EncryptionKey[Index]);
                EncryptionKey[Index] = Encrypt(EncryptionKey[Index], false);

                Array.Copy(BigDataBlock, Index * PlainSmallDataBlockLength, SmallDataBlock, 0, PlainSmallDataBlockLength);
                Array.Copy(EncryptSmallDataBlock(SmallDataBlock), 0, Encrypted, SubstitutionBox[Index] * CryptSmallDataBlockLength, CryptSmallDataBlockLength);
            }
            return Encrypted;
        }

        /// <summary>
        /// Encrypt data block with transposition of its elements.
        /// </summary>
        /// <param name="DataBlock">DataBlock.Length == PlainBigDataBlockLength unless last data block is reached.</param>
        /// <param name="LastDataBlock">If true, last data block is reached.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>

        public byte[] Encrypt(byte[] DataBlock, bool LastDataBlock)
        {
            if (DataBlock == null) return null;
            if (DataBlock.Length > PlainBigDataBlockLength) throw new ArgumentOutOfRangeException("DataBlock.Length: " + DataBlock.Length);
            if (!LastDataBlock && DataBlock.Length != PlainBigDataBlockLength) throw new ArgumentOutOfRangeException("DataBlock.Length: " + DataBlock.Length);

            if (!LastDataBlock) return EncryptBigDataBlock(DataBlock);

            if (DataBlock.Length < PlainBigDataBlockLength)
            {
                byte[] Extension = naPool.GetNextRandomBytes(PlainSmallDataBlockLength - DataBlock.Length % PlainSmallDataBlockLength);
                Extension[Extension.Length - 1] = (byte)(PlainSmallDataBlockLength - Extension.Length);

                Array.Resize(ref DataBlock, DataBlock.Length + Extension.Length);
                Array.Copy(Extension, 0, DataBlock, DataBlock.Length - Extension.Length, Extension.Length);
                return EncryptBigDataBlock(DataBlock);
            }
            else
            {
                DataBlock = EncryptBigDataBlock(DataBlock);
                byte[] Extension = naPool.GetNextRandomBytes(PlainSmallDataBlockLength);
                Extension[Extension.Length - 1] = 0;

                Extension = EncryptBigDataBlock(Extension);
                Array.Resize(ref DataBlock, DataBlock.Length + Extension.Length);
                Array.Copy(Extension, 0, DataBlock, DataBlock.Length - Extension.Length, Extension.Length);
                return DataBlock;
            }
        }

        /// <summary>
        /// Resize small data block to original length.
        /// </summary>
        /// <param name="SmallDataBlock"></param>
        /// <returns></returns>

        private byte[] Resize(byte[] SmallDataBlock)
        {
            for (int Index = 0; Index < SmallDataBlock.Length; Index += 2) SmallDataBlock[Index / 2] = SmallDataBlock[Index];
            Array.Resize(ref SmallDataBlock, SmallDataBlock.Length / 2 - 1);
            return SmallDataBlock;
        }

        /// <summary>
        /// Set naCrypt and feedback to previous state.
        /// </summary>
        /// <param name="Cipher"></param>

        private void Rewind(byte Cipher)
        {
            naPRNG.SetPreviousState();
            Feedback = GetPreviousFeedback(Cipher);
        }

        /// <summary>
        /// True, if decrypted pair is equal.
        /// </summary>
        /// <param name="Cipher1"></param>
        /// <param name="Cipher2"></param>
        /// <returns></returns>

        private bool IsEqualDecrypted(byte Cipher1, byte Cipher2)
        {
            byte Plain1 = Decrypt(Cipher1);
            byte Plain2 = Decrypt(Cipher2);
            Rewind(Cipher2);
            Rewind(Cipher1);

            return (Plain1 == Plain2);
        }

        /// <summary>
        /// Trying to correct inconsistent data.
        /// </summary>
        /// <param name="SmallDataBlock"></param>
        /// <param name="Substitution"></param>
        /// <param name="Decrypted"></param>
        /// <param name="Index"></param>
        /// <returns></returns>

        private byte[] TryDataCorrection(byte[] SmallDataBlock, byte[] Substitution, byte[] Decrypted, int Index)
        {
            if (InconsistentDataError == InconsistentDataErrors.Resists) return Decrypted;

            // If the dummy pair only is affected there is no need to recover some data.
            if (Index == CryptSmallDataBlockLength - 1)
            {
                InconsistentDataError = InconsistentDataErrors.Repaired;
                Decrypted[Index] = Decrypted[Index - 1];
                return Decrypted;
            }

            // Go one step back to start correction.
            byte Cipher1 = SmallDataBlock[Substitution[Index - 1]];
            byte Cipher2 = SmallDataBlock[Substitution[Index]];

            Rewind(Cipher2);
            Rewind(Cipher1);

            for (int Plain = 0; Plain < 256; Plain++)
            {
                // Encrypt the current plain pair.
                Cipher1 = Encrypt((byte)Plain, HighReliability);
                Cipher2 = Encrypt((byte)Plain, HighReliability);

                // If the current plain value is equal to the first originally decrypted value
                // or the second current cipher is equal to the second originally encrypted value,
                // it is possible that the correct pair is found.

                if (Plain == Decrypted[Index - 1] || Cipher2 == SmallDataBlock[Substitution[Index]])
                {
                    // If furthermore the decryption of the following encrypted pair leads to a valid plain pair it is taken for granted.
                    if (IsEqualDecrypted(SmallDataBlock[Substitution[Index + 1]], SmallDataBlock[Substitution[Index + 2]]))
                    {
                        InconsistentDataError = InconsistentDataErrors.Repaired;
                        Decrypted[Index - 1] = (byte)Plain;
                        Decrypted[Index] = (byte)Plain;
                        return Decrypted;
                    }
                }

                // No valid pair found, so go one step back again and try another one.
                Rewind(Cipher2);
                Rewind(Cipher1);
            }

            // No success at all.
            InconsistentDataError = InconsistentDataErrors.Resists;
            Encrypt(Decrypted[Index - 1], HighReliability);
            Encrypt(Decrypted[Index], HighReliability);
            return Decrypted;
        }

        /// <summary>
        /// Decrypt a single byte.
        /// </summary>
        /// <param name="Cipher"></param>
        /// <returns></returns>

        private byte Decrypt(byte Cipher)
        {
            byte Plain = (byte)(Cipher ^ CurrentSecureValue);
            if (HighReliability)
            {
                Plain = (byte)(Plain ^ Feedback);
                Feedback = GetFeedback(Cipher);
            }
            naPRNG.SetNextState();
            return Plain;
        }

        /// <summary>
        /// Decrypt small data block with transposition of its elements.
        /// </summary>
        /// <param name="SmallDataBlock"></param>
        /// <returns></returns>

        private byte[] DecryptSmallDataBlock(byte[] SmallDataBlock)
        {
            byte[] Decrypted = new byte[CryptSmallDataBlockLength];
            byte[] SubstitutionBox = GetSubstitutionBox(CryptSmallDataBlockLength);

            if (HighReliability) ResetFeedback();
            for (int Index = 0; Index < CryptSmallDataBlockLength; Index++)
            {
                if (!HighReliability) EncryptionKey[Index] = (byte)(EncryptionKey[Index] ^ SmallDataBlock[SubstitutionBox[Index]]);
                Decrypted[Index] = Decrypt(SmallDataBlock[SubstitutionBox[Index]]);
                if (HighReliability && (Index % 2 == 1) && (Decrypted[Index] != Decrypted[Index - 1])) Decrypted = TryDataCorrection(SmallDataBlock, SubstitutionBox, Decrypted, Index);
            }

            if (HighReliability) return Resize(Decrypted);
            return Decrypted;
        }

        /// <summary>
        /// Decrypt big data block with transposition of its small data blocks.
        /// </summary>
        /// <param name="BigDataBlock"></param>
        /// <returns></returns>

        private byte[] DecryptBigDataBlock(byte[] BigDataBlock)
        {
            byte[] SmallDataBlock = new byte[CryptSmallDataBlockLength];
            int NumberOfBlocks = BigDataBlock.Length / CryptSmallDataBlockLength;

            byte[] Decrypted = new byte[PlainSmallDataBlockLength * NumberOfBlocks];
            byte[] SubstitutionBox = GetSubstitutionBox(NumberOfBlocks);

            for (int Index = 0; Index < NumberOfBlocks; Index++)
            {
                naPRNG.GatherEntropy(EncryptionKey[Index]);
                EncryptionKey[Index] = Encrypt(EncryptionKey[Index], false);

                Array.Copy(BigDataBlock, SubstitutionBox[Index] * CryptSmallDataBlockLength, SmallDataBlock, 0, CryptSmallDataBlockLength);
                Array.Copy(DecryptSmallDataBlock(SmallDataBlock), 0, Decrypted, Index * PlainSmallDataBlockLength, PlainSmallDataBlockLength);
            }
            return Decrypted;
        }

        /// <summary>
        /// Decrypt data block with transposition of its elenents.
        /// </summary>
        /// <param name="DataBlock">DataBlock.Length == CryptBigDataBlockLength unless last data block is reached.</param>
        /// <param name="LastDataBlock">If true, last data block is reached.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>

        public byte[] Decrypt(byte[] DataBlock, bool LastDataBlock)
        {
            if (DataBlock == null) return null;
            if (DataBlock.Length > CryptBigDataBlockLength) throw new ArgumentOutOfRangeException("DataBlock.Length: " + DataBlock.Length);
            if (!LastDataBlock && DataBlock.Length != CryptBigDataBlockLength) throw new ArgumentOutOfRangeException("DataBlock.Length: " + DataBlock.Length);
            if (DataBlock.Length % CryptSmallDataBlockLength != 0) throw new ArgumentOutOfRangeException("DataBlock.Length: " + DataBlock.Length);

            DataBlock = DecryptBigDataBlock(DataBlock);
            if (LastDataBlock) Array.Resize(ref DataBlock, DataBlock.Length + DataBlock[DataBlock.Length - 1] - PlainSmallDataBlockLength);
            return DataBlock;
        }
    }
}
#pragma warning restore