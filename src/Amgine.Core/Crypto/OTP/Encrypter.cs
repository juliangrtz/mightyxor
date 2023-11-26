using Amgine.Common.Exceptions;
using Amgine.Common.Logging;
using Amgine.Common.Serialization;
using Amgine.Common.Utility;
using Amgine.Core.IO;
using Amgine.Core.Models;
using LogLevel = Amgine.Common.Logging.LogLevel;

namespace Amgine.Core.Crypto.OTP;

/// <summary>
/// Encryption helper class used for a <see cref="OneTimePad"/>.
/// Counterpart of the <see cref="Decrypter"/>.
/// </summary>
public class Encrypter
{
    public const string EncryptedFileExtension = ".encrypted";

    private readonly FileInfo _plaintextInfo, _keyInfo;
    private readonly byte[] _plaintext, _key;

    private readonly BsonSerializer _bsonSerializer;
    private readonly AmgineSettings _settings;

    /// <summary>
    /// Constructs a new one-time pad encrypter.
    /// </summary>
    /// <param name="settings">Settings to use</param>
    /// <param name="plaintextPath">Path to the plaintext</param>
    /// <param name="keyPath">Path to the key</param>
    public Encrypter(AmgineSettings settings, string plaintextPath, string keyPath)
    {
        (_plaintextInfo, _plaintext) = new FileReader(plaintextPath).ReadFileData();
        (_keyInfo, _key) = new FileReader(keyPath).ReadFileData();

        if (settings.OverrideFile && _plaintextInfo.IsReadOnly)
            throw new ArgumentException($"Cannot override {plaintextPath}. It is read-only.");

        _settings = settings;
        _bsonSerializer = new BsonSerializer();

        Log("Encrypter initialized.", LogType.Info, LogLevel.Diagnostic);
    }

    private AmgineFileHeader BuildHeader()
    {
        Log("Crafting header...", LogType.Debug, LogLevel.Detailed);

        var hashUtil = new HashUtil(HashType.MD5);
        var amgineFileHeader = new AmgineFileHeader(_plaintextInfo, hashUtil.GenerateHash(_plaintext));

        Log($"Header ({amgineFileHeader.Length} bytes): {amgineFileHeader}", LogType.Debug, LogLevel.Diagnostic);
        return amgineFileHeader;
    }

    private byte[] SerializeAmgineFile(AmgineFileHeader? amgineFileHeader)
    {
        Log("Serializing...", LogType.Debug, LogLevel.Detailed);
        var amgineFile = new AmgineFile(amgineFileHeader, _plaintext);
        var serializedAmgineFile = _bsonSerializer.SerializeObject(amgineFile).ToArray();
        return serializedAmgineFile;
    }

    private void CheckKeyLength(byte[] serializedFileLength)
    {
        if (_keyInfo.Length < serializedFileLength.Length)
        {
            throw new InvalidKeyException($"The provided key is too small ({_key.Length} bytes). " +
                                          $"Due to the header, it has to have at least {serializedFileLength.Length} bytes.");
        }
    }

    private byte[] EncryptAmgineFile(byte[] serializedAmgineFile)
    {
        Log("Encrypting via XOR...", LogType.Debug, LogLevel.Detailed);
        var xorCalculator = new XorCalculator(xor64BitsAtATime: true);
        var encryptedAmgineFile = xorCalculator.Xor(serializedAmgineFile, _key);
        Log("Encryption succeeded. Writing ciphertext...", LogType.Info, LogLevel.Detailed);
        return encryptedAmgineFile;
    }

    private void WriteCiphertext(byte[] ciphertext)
    {
        var path = _settings.OverrideFile ? _plaintextInfo.FullName
            : _settings.OutputDirectory + $"\\{_plaintextInfo.Name}{EncryptedFileExtension}";

        File.WriteAllBytes(path, ciphertext);

        // Should the new ciphertext be read-only?
        if (_settings.SetCiphertextReadOnly)
            File.SetAttributes(path, FileAttributes.ReadOnly);
    }

    /// <summary>
    /// Encrypts the specified plaintext with the given key via one-time pad.
    /// </summary>
    public void Encrypt()
    {
        Log("Encryption started.", LogType.Info, LogLevel.Minimal);

        // Header construction
        var amgineFileHeader = _settings.UseFileHeader ? BuildHeader() : null;

        // Serialization
        var serializedAmgineFile = SerializeAmgineFile(amgineFileHeader);

        // Check if the key is large enough
        CheckKeyLength(serializedAmgineFile);

        // Encryption
        var encryptedAmgineFile = EncryptAmgineFile(serializedAmgineFile);

        // Finalization
        WriteCiphertext(encryptedAmgineFile);

        Log("Encryption finished.", LogType.Info, LogLevel.Minimal);
    }
}