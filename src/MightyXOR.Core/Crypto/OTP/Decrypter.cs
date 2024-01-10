using MightyXOR.Common.Exceptions;
using MightyXOR.Common.Logging;
using MightyXOR.Common.Serialization;
using MightyXOR.Core.IO;
using MightyXOR.Core.Models;
using LogLevel = MightyXOR.Common.Logging.LogLevel;

namespace MightyXOR.Core.Crypto.OTP;

/// <summary>
/// Decryption helper class used for a <see cref="OneTimePad"/>.
/// Counterpart of the <see cref="Encrypter"/>.
/// </summary>
public class Decrypter
{
    public const string DecryptedFileExtension = ".decrypted";

    private readonly FileInfo _keyInfo, _ciphertextInfo;
    private readonly byte[] _ciphertext, _key;

    private readonly BsonSerializer _bsonSerializer;
    private readonly MightyXorSettings _settings;

    /// <summary>
    /// Constructs a new one-time pad decrypter.
    /// </summary>
    /// <param name="settings">Settings to use</param>
    /// <param name="ciphertextPath">Path to the ciphertext</param>
    /// <param name="keyPath">Path to the key</param>
    public Decrypter(MightyXorSettings settings, string ciphertextPath, string keyPath)
    {
        (_ciphertextInfo, _ciphertext) = new FileReader(ciphertextPath).ReadFileData();
        (_keyInfo, _key) = new FileReader(keyPath).ReadFileData();

        if (settings.OverrideFile && _ciphertextInfo.IsReadOnly)
            throw new ArgumentException($"Cannot override {ciphertextPath}. It is read-only.");

        _settings = settings;
        _bsonSerializer = new BsonSerializer();

        Log("Decrypter initialized.", LogType.Info, LogLevel.Diagnostic);
    }

    private MightyXorFile Deserialize(byte[] decryptedBytes)
    {
        var deserializedFile = _bsonSerializer.DeserializeObject<MightyXorFile>(decryptedBytes) 
                               ?? throw new SerializationException("Deserialization failed.");
        Log(deserializedFile.Header?.ToString() ?? string.Empty, LogType.Debug, LogLevel.Diagnostic);
        Log("Deserialization succeeded.", LogType.Debug, LogLevel.Detailed);

        return deserializedFile;
    }

    private static void CheckHashes(MightyXorFile mightyXorFile)
    {
        Log("Comparing hashes...", LogType.Debug, LogLevel.Detailed);
        if (!mightyXorFile.CompareHashes())
        {
            throw new HashMismatchException("The MD5 hash in the header does not match the actual hash of the content.");
            // ToDo: Further behaviour?
        }
    }

    private void WritePlaintext(MightyXorFile deserializedMightyXorFile)
    {
        Log("Writing file and restoring metadata...", LogType.Debug, LogLevel.Detailed);

        // Path used if header is null
        var fallbackPath = _ciphertextInfo.Name.Replace(".encrypted", "") + DecryptedFileExtension;

        var path = _settings.OverrideFile ? _ciphertextInfo.FullName
            : _settings.OutputDirectory + $"\\{deserializedMightyXorFile.Header?.Name ?? fallbackPath}";

        deserializedMightyXorFile.PersistContent(path);
    }

    private void DeleteKey()
    {
        var fileWiper = new FileWiper(_keyInfo.FullName);
        fileWiper.WipeFile(_settings.TimesToOverrideDeletedFiles);
    }

    /// <summary>
    /// Decrypts the specified ciphertext with the given key via one-time pad.
    /// </summary>
    public MightyXorFile Decrypt()
    {
        Log("Decryption started.", LogLevel.Minimal);

        // Restore plaintext via XOR
        Log("Decrypting the ciphertext...", LogLevel.Detailed);
        var xorCalculator = new XorCalculator(xor64BitsAtATime: true);
        var decryptedBytes = xorCalculator.Xor(_ciphertext.ToArray(), _key);

        // Deserialize
        Log("Deserializing the decrypted result...", LogType.Debug, LogLevel.Detailed);
        var deserializedFile = Deserialize(decryptedBytes);

        // Hash check
        if (_settings.CompareHashesInHeader)
            CheckHashes(deserializedFile);

        // Restore plaintext
        WritePlaintext(deserializedFile);

        // Delete key if it is wanted
        if (_settings.DeleteKeyAfterDecryption)
            DeleteKey();

        Log("Decryption succeeded.", LogLevel.Minimal);
        return deserializedFile;
    }
}