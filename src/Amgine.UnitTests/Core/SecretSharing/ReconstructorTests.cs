using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Amgine.Common;
using Amgine.Common.Utility;
using Amgine.Core.Crypto.KeyGenerators;
using Amgine.Core.Models;
using Amgine.Core.SecretSharing.Shamir;
using NUnit.Framework;

namespace Amgine.UnitTests.Core.SecretSharing
{
    internal class ReconstructorTests
    {
        private const string TestfilePath = "test_secret.bin";
        private const string RecoveredSecretPath = "secret.bin";
        private const int TestfileLength = 8192;
        private readonly PRNG _prng = new();

        private byte[] _secretBytes = null!;
        private Distributor _distributor = null!;
        private Reconstructor _reconstructor = null!;

        [SetUp]
        public void SetUp()
        {
            _secretBytes = _prng.GenerateKey(TestfileLength);
            File.WriteAllBytes(TestfilePath, _secretBytes);

            _distributor = new Distributor(TestfilePath);
        }

        [TearDown]
        public void TearDown()
        {
            var directory = Path.GetDirectoryName(Path.GetFullPath(TestfilePath)) ?? Environment.CurrentDirectory;
            var shareFiles = Directory.EnumerateFiles(directory, "*.share").ToList();
            shareFiles.ForEach(File.Delete);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            new FileInfo(TestfilePath).DeleteIfExists();
            new FileInfo(RecoveredSecretPath).DeleteIfExists();
        }

        [Test]
        public void Test_Zero_Shares()
        {
            // Given
            var shares = Array.Empty<string>();

            // When/Then
            Assert.Throws<ArgumentException>(() =>
            {
                _ = new Reconstructor(shares);
            });
        }

        [Test]
        [TestCase(3, 2)]
        [TestCase(8, 6)]
        public void Test_Correctness_For_All_Permutations(byte n, byte k)
        {
            // Given
            var shareFiles = _distributor.GenerateFileShares(n, k);

            // When
            var subSets = shareFiles.SubSets()
                .Where(subset => subset.Count() >= k); // Skip the trivial subsets

            var subSetsEnumerable = subSets as IEnumerable<string>[] ?? subSets.ToArray();
            for (var i = 0; i < subSetsEnumerable.Length; i++)
            {
                var permutation = subSetsEnumerable.ElementAt(i).ToArray();
                _reconstructor = new Reconstructor(permutation);
                _reconstructor.Reconstruct(k, isAmgineFile: false, Environment.CurrentDirectory);

                // Then
                FileAssert.AreEqual(TestfilePath, RecoveredSecretPath);
            }
        }

        [Test]
        [TestCase(3, 2)]
        [TestCase(8, 6)]
        [TestCase(20, 19)]
        public void Test_AmgineFile_Reconstruction(byte n, byte k)
        {
            // Given
            var header = new AmgineFileHeader(new FileInfo(TestfilePath),
                                              new HashUtil(HashType.MD5).GenerateHash(_secretBytes));
            var amgineFile = new AmgineFile(header, _secretBytes);

            _distributor = new Distributor(amgineFile);
            var shares = _distributor.GenerateFileShares(n, k).ToArray();

            // When
            _reconstructor = new Reconstructor(shares);
            _reconstructor.Reconstruct(k, isAmgineFile: true, Environment.CurrentDirectory);

            // Then
            FileAssert.AreEqual(TestfilePath, amgineFile.Header?.Name);
        }
    }
}