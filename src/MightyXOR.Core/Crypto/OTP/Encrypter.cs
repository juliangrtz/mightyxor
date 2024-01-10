using MightyXOR.Common.Exceptions;
using MightyXOR.Common.Logging;
using MightyXOR.Common.Serialization;
using MightyXOR.Common.Utility;
using MightyXOR.Core.IO;
using MightyXOR.Core.Models;
using LogLevel = MightyXOR.Common.Logging.LogLevel;

namespace MightyXOR.Core.Crypto.OTP;

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
    private readonly MightyXorSettings _settings;

    /// <summary>
    /// Constructs a new one-time pad encrypter.
    /// </summary>
    /// <param name="settings">Settings to use</param>
    /// <param name="plaintextPath">Path to the plaintext</param>
    /// <param name="keyPath">Path to the key</param>
    public Encrypter(MightyXorSettings settings, string plaintextPath, string keyPath)
    {
        (_plaintextInfo, _plaintext) = new FileReader(plaintextPath).ReadFileData();
        (_keyInfo, _key) = new FileReader(keyPath).ReadFileData();

        if (settings.OverrideFile && _plaintextInfo.IsReadOnly)
            throw new ArgumentException($"Cannot override {plaintextPath}. It is read-only.");

        _settings = settings;
        _bsonSerializer = new BsonSerializer();

        Log("Encrypter initialized.", LogType.Info, LogLevel.Diagnostic);
    }

    private MightyXorFileHeader BuildHeader()
    {
        Log("Crafting header...", LogType.Debug, LogLevel.Detailed);

        var hashUtil = new HashUtil(HashType.MD5);
        var header = new MightyXorFileHeader(_plaintextInfo, hashUtil.GenerateHash(_plaintext));

        Log($"Header ({header.Length} bytes): {header}", LogType.Debug, LogLevel.Diagnostic);
        return header;
    }

    private byte[] SerializeMightyXorFile(MightyXorFileHeader? header)
    {
        Log("Serializing...", LogType.Debug, LogLevel.Detailed);
        var mightyXorFile = new MightyXorFile(header, _plaintext);
        var serializedFile = _bsonSerializer.SerializeObject(mightyXorFile).ToArray();
        return serializedFile;
    }

    private void CheckKeyLength(IReadOnlyCollection<byte> serializedFileLength)
    {
        if (_keyInfo.Length < serializedFileLength.Count)
        {
            throw new InvalidKeyException($"The provided key is too small ({_key.Length} bytes). " +
                                          $"Due to the header, it has to have at least {serializedFileLength.Count} bytes.");
        }
    }

    private byte[] EncryptMightyXorFile(byte[] serializedMightyXorFile)
    {
        Log("Encrypting via XOR...", LogType.Debug, LogLevel.Detailed);
        var xorCalculator = new XorCalculator(xor64BitsAtATime: true);
        var emncryptedFile = xorCalculator.Xor(serializedMightyXorFile, _key);
        Log("Encryption succeeded. Writing ciphertext...", LogType.Info, LogLevel.Detailed);
        return emncryptedFile;
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
        var fileHeader = _settings.UseFileHeader ? BuildHeader() : null;

        // Serialization
        var serializedFile = SerializeMightyXorFile(fileHeader);

        // Check if the key is large enough
        CheckKeyLength(serializedFile);

        // Encryption
        var encryptedFile = EncryptMightyXorFile(serializedFile);

        // Finalization
        WriteCiphertext(encryptedFile);

        Log("Encryption finished.", LogType.Info, LogLevel.Minimal);
    }
}