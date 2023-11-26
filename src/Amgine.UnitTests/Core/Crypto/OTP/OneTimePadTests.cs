using Amgine.Common.Exceptions;
using Amgine.Common.Utility;
using Amgine.Core.Crypto.KeyGenerators;
using Amgine.Core.Crypto.OTP;
using Amgine.Core.Models;
using NUnit.Framework;
using System;
using System.IO;

namespace Amgine.UnitTests.Core.Crypto.OTP;

public class OneTimePadTests
{
    private const string NotExistingFilePath = "not_existing_file.42";
    private const string TestfilePath = "testcase.bin";
    private const string TestkeyPath = "testcase.key";

    private const long KeySize = 2048;
    private const long LargeTestfileSize = int.MaxValue / 8; // approx. 500 MB

    private byte[]? _key;

    private readonly PRNG _prng = new();

    private readonly AmgineSettings _settings = new();
    private OneTimePad _oneTimePad = null!;

    [SetUp]
    public void Setup()
    {
        _key = _prng.GenerateKey(KeySize);
        File.WriteAllBytes(TestkeyPath, _key);

        _settings.OverrideFile = true;
        _oneTimePad = new OneTimePad(_settings, TestkeyPath);
    }

    [TearDown]
    public void TearDown()
    {
        File.Delete(TestkeyPath);
    }

    [Test]
    public void TestNonExistingFile_Encrypt()
    {
        var exception = Assert.Throws<InvalidFileException>(() => _oneTimePad.EncryptFile(NotExistingFilePath));
        Assert.That(exception?.Message, Is.EqualTo($"The provided file path {NotExistingFilePath} does not point to an existing file."));
    }

    [Test]
    public void TestNonExistingFile_Decrypt()
    {
        var exception = Assert.Throws<InvalidFileException>(() => _oneTimePad.DecryptFile(NotExistingFilePath));
        Assert.That(exception?.Message, Is.EqualTo($"The provided file path {NotExistingFilePath} does not point to an existing file."));
    }

    [Test]
    public void TestEmptyFile_Encrypt()
    {
        // Given
        File.WriteAllBytes(TestfilePath, Array.Empty<byte>());

        // When/Then
        var exception = Assert.Throws<InvalidFileException>(() => _oneTimePad.EncryptFile(TestfilePath));
        Assert.That(exception?.Message, Is.EqualTo($"{TestfilePath} is empty."));
        File.Delete(TestfilePath);
    }

    [Test]
    public void TestEmptyFile_Decrypt()
    {
        // Given
        File.WriteAllBytes(TestfilePath, Array.Empty<byte>());

        // When/Then
        var exception = Assert.Throws<InvalidFileException>(() => _oneTimePad.DecryptFile(TestfilePath));
        Assert.That(exception?.Message, Is.EqualTo($"{TestfilePath} is empty."));
        File.Delete(TestfilePath);
    }

    [Test]
    [TestCase(new byte[] { 0xCA, 0xFE, 0xBA, 0xBE })]
    [TestCase(new byte[] { 0x00, 0x00, 0xDE, 0xAD, 0xBE, 0xEF, 0x00, 0x00 })]
    public void TestCorrectness(byte[] bytes)
    {
        // Given
        File.WriteAllBytes(TestfilePath, bytes);
        var fileInfoBefore = new FileInfo(TestfilePath);

        // When
        _oneTimePad.EncryptFile(TestfilePath);
        _oneTimePad.DecryptFile(TestfilePath);
        var decrypted = File.ReadAllBytes(TestfilePath);
        var fileInfoAfter = new FileInfo(TestfilePath);

        // Then
        Assert.AreEqual(fileInfoBefore.Length, fileInfoAfter.Length);
        Assert.AreEqual(bytes, decrypted);

        File.Delete(TestfilePath);
    }

    [Test]
    [Ignore(reason: "Ignored for performance reasons")]
    public void TestLargeFile()
    {
        // Given
        var largeFile = _prng.GenerateKey(LargeTestfileSize);
        var key = _prng.GenerateKey(LargeTestfileSize * 2 + 1024);
        File.WriteAllBytes(TestfilePath, largeFile);
        File.WriteAllBytes(TestkeyPath, key);

        // When
        var otp = new OneTimePad(TestkeyPath);
        otp.EncryptFile(TestfilePath);
        otp.DecryptFile(TestfilePath);

        // Then
        var decrypted = File.ReadAllBytes(TestfilePath);

        // Hash-wise comparison for performance reasons
        var hashUtil = new HashUtil(HashType.MD5);
        Assert.AreEqual(hashUtil.GenerateHash(decrypted), hashUtil.GenerateHash(largeFile));
        File.Delete(TestfilePath);
    }
}