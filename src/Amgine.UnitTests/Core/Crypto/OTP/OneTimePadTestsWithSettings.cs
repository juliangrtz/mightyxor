using Amgine.Common.Exceptions;
using Amgine.Core.Crypto.KeyGenerators;
using Amgine.Core.Crypto.OTP;
using Amgine.Core.Models;
using NUnit.Framework;
using System.IO;
using Amgine.Common;

namespace Amgine.UnitTests.Core.Crypto.OTP;

public class OneTimePadTestsWithSettings
{
    private const string TestfilePath = "testcase.bin";
    private const string TestkeyPath = "testcase.key";

    private const long FileSize = 4096;
    private const long KeySize = FileSize * 4;

    private byte[]? _fileBuffer, _keyBuffer;
    private readonly PRNG _prng = new();

    [SetUp]
    public void Setup()
    {
        _fileBuffer = _prng.GenerateKey(FileSize);
        _keyBuffer = _prng.GenerateKey(KeySize);

        File.WriteAllBytes(TestfilePath, _fileBuffer);
        File.WriteAllBytes(TestkeyPath, _keyBuffer);
    }

    [TearDown]
    public void TearDown()
    {
        new FileInfo(TestfilePath).DeleteIfExists();
        new FileInfo(TestfilePath + ".encrypted").DeleteIfExists();
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        new FileInfo(TestkeyPath).DeleteIfExists();
    }

    [Test]
    public void Test_UseFileHeader_Setting_True()
    {
        // Given
        var settings = new AmgineSettings
        {
            OverrideFile = true, // For the sake of simplicity
            UseFileHeader = true
        };

        // When
        var otp = new OneTimePad(settings, TestkeyPath);

        otp.EncryptFile(TestfilePath);
        var amgineFile = otp.DecryptFile(TestfilePath);

        // Then
        Assert.IsNotNull(amgineFile.Header);
        Assert.AreEqual(amgineFile.Header?.Length, amgineFile.Content.Length);
    }

    [Test]
    public void Test_UseFileHeader_Setting_False()
    {
        // Given
        var settings = new AmgineSettings
        {
            OverrideFile = true,
            UseFileHeader = false
        };

        // When
        var otp = new OneTimePad(settings, TestkeyPath);
        otp.EncryptFile(TestfilePath);
        var amgineFile = otp.DecryptFile(TestfilePath);

        // Then
        Assert.IsNull(amgineFile.Header);
        Assert.IsNotEmpty(amgineFile.Content);
    }

    [Test]
    public void Test_CompareHashesInHeader_Setting_True()
    {
        // Given
        var settings = new AmgineSettings
        {
            OverrideFile = true,
            CompareHashesInHeader = true
        };

        // When
        var otp = new OneTimePad(settings, TestkeyPath);
        otp.EncryptFile(TestfilePath);

        var position = (int)new FileInfo(TestfilePath).Length - 10;
        Util.ReplaceData(TestfilePath, position, new byte[] { 0xAB, 0xBA, 0xAB, 0xBA });

        // Then
        Assert.Throws<HashMismatchException>(() => otp.DecryptFile(TestfilePath));
    }

    [Test]
    public void Test_CompareHashesInHeader_Setting_False()
    {
        // Given
        var settings = new AmgineSettings
        {
            OverrideFile = true,
            CompareHashesInHeader = false
        };

        // When
        var otp = new OneTimePad(settings, TestkeyPath);
        otp.EncryptFile(TestfilePath);

        var position = (int)new FileInfo(TestfilePath).Length / 2;
        Util.ReplaceData(TestfilePath, position, new byte[] { 0xAB, 0xBA, 0xAB, 0xBA });

        // Then
        Assert.DoesNotThrow(() => otp.DecryptFile(TestfilePath), "The MD5 hash in the header does not match the actual hash of the content.");
    }

    [Test]
    public void Test_DeleteKeyAfterDecryption_Setting_True()
    {
        // Given
        var settings = new AmgineSettings
        {
            OverrideFile = true,
            DeleteKeyAfterDecryption = true
        };

        // When
        var otp = new OneTimePad(settings, TestkeyPath);
        otp.EncryptFile(TestfilePath);
        otp.DecryptFile(TestfilePath);

        // Then
        FileAssert.DoesNotExist(TestkeyPath);
    }

    [Test]
    public void Test_DeleteKeyAfterDecryption_Setting_False()
    {
        // Given
        var settings = new AmgineSettings
        {
            OverrideFile = true,
            DeleteKeyAfterDecryption = false
        };

        // When
        var otp = new OneTimePad(settings, TestkeyPath);
        otp.EncryptFile(TestfilePath);
        otp.DecryptFile(TestfilePath);

        // Then
        FileAssert.Exists(TestkeyPath);
    }

    [Test]
    public void Test_OverridePlaintextFile_Setting_True()
    {
        // Given
        var settings = new AmgineSettings
        {
            OverrideFile = true
        };

        // When
        var before = File.ReadAllBytes(TestfilePath);

        var otp = new OneTimePad(settings, TestkeyPath);
        otp.EncryptFile(TestfilePath);

        var after = File.ReadAllBytes(TestfilePath);

        // Then
        Assert.AreNotEqual(before, after);
    }

    [Test]
    public void Test_OverridePlaintextFile_Setting_False()
    {
        // Given
        var settings = new AmgineSettings
        {
            OverrideFile = false
        };

        // When
        var before = File.ReadAllBytes(TestfilePath);

        var otp = new OneTimePad(settings, TestkeyPath);
        otp.EncryptFile(TestfilePath);

        var after = File.ReadAllBytes(TestfilePath);

        // Then
        Assert.AreEqual(before, after);
    }

    [Test]
    public void Test_SetCiphertextReadonly_Setting_True()
    {
        // Given
        var settings = new AmgineSettings
        {
            OverrideFile = true,
            SetCiphertextReadOnly = true
        };

        // When
        var otp = new OneTimePad(settings, TestkeyPath);
        otp.EncryptFile(TestfilePath);

        // Then
        Assert.IsTrue(new FileInfo(TestfilePath).IsReadOnly);
        File.SetAttributes(TestfilePath, ~FileAttributes.ReadOnly);
    }

    [Test]
    public void Test_SetCiphertextReadonly_Setting_False()
    {
        // Given
        var settings = new AmgineSettings
        {
            OverrideFile = true,
            SetCiphertextReadOnly = false
        };

        // When
        var otp = new OneTimePad(settings, TestkeyPath);
        otp.EncryptFile(TestfilePath);

        // Then
        Assert.IsFalse(new FileInfo(TestfilePath).IsReadOnly);
    }
}