using System;
using System.IO;
using System.Linq;
using Amgine.Common;
using Amgine.Core.Crypto.KeyGenerators;
using Amgine.Core.SecretSharing.Shamir;
using NUnit.Framework;

namespace Amgine.UnitTests.Core.SecretSharing
{
    internal class DistributorTests
    {
        private const string TestfilePath = "secret.bin";
        private const int TestfileLength = 4096;

        private readonly PRNG _prng = new();
        private Distributor _distributor = null!;

        [SetUp]
        public void SetUp()
        {
            File.WriteAllBytes(TestfilePath, _prng.GenerateKey(TestfileLength));
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
        public void OneTimeTearDown() => new FileInfo(TestfilePath).DeleteIfExists();

        [Test]
        [TestCase(0, 0)]
        [TestCase(3, 0)]
        [TestCase(3, 4)]
        public void Test_Invalid_Arguments(byte n, byte k)
        {
            // When/Then
            Assert.That(() => _distributor.GenerateFileShares(n, k), Throws.Exception);
        }

        [Test]
        [TestCase(3, 2)]
        [TestCase(10, 3)]
        [TestCase(25, 15)]
        public void Test_Secret_Distribution(byte n, byte k)
        {
            // When
            _distributor.GenerateFileShares(n, k);

            // Then
            var expectedShareLength = new FileInfo(TestfilePath).Length + 1; // +1 due to the prepended X value
            for (var i = 0; i < n; i++)
            {
                var sharePath = $"{TestfilePath}_{i + 1}{Distributor.ShareFileExtension}";
                FileAssert.Exists(sharePath);
                Assert.AreEqual(expectedShareLength, new FileInfo(sharePath).Length);
            }
        }
    }
}