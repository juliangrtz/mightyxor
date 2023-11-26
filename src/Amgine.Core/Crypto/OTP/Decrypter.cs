using Amgine.Common.Exceptions;
using Amgine.Common.Logging;
using Amgine.Common.Serialization;
using Amgine.Core.IO;
using Amgine.Core.Models;
using LogLevel = Amgine.Common.Logging.LogLevel;

namespace Amgine.Core.Crypto.OTP;

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
    private readonly AmgineSettings _settings;

    /// <summary>
    /// Constructs a new one-time pad decrypter.
    /// </summary>
    /// <param name="settings">Settings to use</param>
    /// <param name="ciphertextPath">Path to the ciphertext</param>
    /// <param name="keyPath">Path to the key</param>
    public Decrypter(AmgineSettings settings, string ciphertextPath, string keyPath)
    {
        (_ciphertextInfo, _ciphertext) = new FileReader(ciphertextPath).ReadFileData();
        (_keyInfo, _key) = new FileReader(keyPath).ReadFileData();

        if (settings.OverrideFile && _ciphertextInfo.IsReadOnly)
            throw new ArgumentException($"Cannot override {ciphertextPath}. It is read-only.");

        _settings = settings;
        _bsonSerializer = new BsonSerializer();

        Log("Decrypter initialized.", LogType.Info, LogLevel.Diagnostic);
    }

    private AmgineFile Deserialize(byte[] decryptedBytes)
    {
        var deserializedAmgineFile = _bsonSerializer.DeserializeObject<AmgineFile>(decryptedBytes);

        if (deserializedAmgineFile == null)
            throw new SerializationException("Deserialization failed.");

        Log(deserializedAmgineFile.Header?.ToString() ?? string.Empty, LogType.Debug, LogLevel.Diagnostic);
        Log("Deserialization succeeded.", LogType.Debug, LogLevel.Detailed);

        return deserializedAmgineFile;
    }

    private static void CheckHashes(AmgineFile amgineFile)
    {
        Log("Comparing hashes...", LogType.Debug, LogLevel.Detailed);
        if (!amgineFile.CompareHashes())
        {
            throw new HashMismatchException("The MD5 hash in the header does not match the actual hash of the content.");
            // ToDo: Further behaviour?
        }
    }

    private void WritePlaintext(AmgineFile deserializedAmgineFile)
    {
        Log("Writing file and restoring metadata...", LogType.Debug, LogLevel.Detailed);

        // Path used if header is null
        var fallbackPath = _ciphertextInfo.Name.Replace(".encrypted", "") + DecryptedFileExtension;

        var path = _settings.OverrideFile ? _ciphertextInfo.FullName
            : _settings.OutputDirectory + $"\\{deserializedAmgineFile.Header?.Name ?? fallbackPath}";

        deserializedAmgineFile.PersistContent(path);
    }

    private void DeleteKey()
    {
        var fileWiper = new FileWiper(_keyInfo.FullName);
        fileWiper.WipeFile(_settings.TimesToOverrideDeletedFiles);
    }

    /// <summary>
    /// Decrypts the specified ciphertext with the given key via one-time pad.
    /// </summary>
    public AmgineFile Decrypt()
    {
        Log("Decryption started.", LogLevel.Minimal);

        // Restore plaintext via XOR
        Log("Decrypting the ciphertext...", LogLevel.Detailed);
        var xorCalculator = new XorCalculator(xor64BitsAtATime: true);
        var decryptedBytes = xorCalculator.Xor(_ciphertext.ToArray(), _key);

        // Deserialize
        Log("Deserializing the decrypted result...", LogType.Debug, LogLevel.Detailed);
        var deserializedAmgineFile = Deserialize(decryptedBytes);

        // Hash check
        if (_settings.CompareHashesInHeader)
            CheckHashes(deserializedAmgineFile);

        // Restore plaintext
        WritePlaintext(deserializedAmgineFile);

        // Delete key if it is wanted
        if (_settings.DeleteKeyAfterDecryption)
            DeleteKey();

        Log("Decryption succeeded.", LogLevel.Minimal);
        return deserializedAmgineFile;
    }
}