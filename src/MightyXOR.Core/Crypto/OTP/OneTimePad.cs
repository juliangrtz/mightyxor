﻿using MightyXOR.Common.Exceptions;
using MightyXOR.Common.Logging;
using MightyXOR.Core.Models;
using LogLevel = MightyXOR.Common.Logging.LogLevel;

namespace MightyXOR.Core.Crypto.OTP;

/// <summary>
/// Implementation of the one-time pad algorithm.
/// See <see href="https://en.wikipedia.org/wiki/One-time_pad">https://en.wikipedia.org/wiki/One-time_pad</see>
/// </summary>
public class OneTimePad
{
    private readonly string _keyPath;
    private readonly MightyXorSettings _settings = new();

    /// <summary>
    /// Constructs a one-time pad with a file path pointing to the key.
    /// </summary>
    /// <param name="filePathToKey">Path to the key used for en-/decryption</param>
    /// <exception cref="InvalidFileException"></exception>
    public OneTimePad(string filePathToKey)
    {
        _keyPath = filePathToKey;

        Log("One-time pad initialized. " +
            $"Key: {filePathToKey}.", LogType.Info, LogLevel.Detailed);
    }

    /// <summary>
    /// Constructs a one-time pad with <see cref="MightyXorSettings"/> and a file path pointing to the key.
    /// </summary>
    /// <param name="settings">Settings to use for the en- and decryption</param>
    /// <param name="filePathToKey">Path to the key used for en-/decryption</param>
    /// <exception cref="InvalidFileException"></exception>
    public OneTimePad(MightyXorSettings settings, string filePathToKey) : this(filePathToKey)
    {
        _settings = settings;
    }

    /// <summary>
    /// Encrypts a plaintext file via one-time pad.
    /// </summary>
    /// <param name="plaintextPath">Path to the plaintext to encrypt</param>
    public void EncryptFile(string plaintextPath)
    {
        var encrypter = new Encrypter(_settings, plaintextPath, _keyPath);
        encrypter.Encrypt();
    }

    /// <summary>
    /// Decrypts a previously encrypted file and rewrites the plaintext file.
    /// </summary>
    /// <param name="ciphertextPath">Path to the file to decrypt</param>
    /// <returns>The deserialized MightyXorFile (null if decryption failed)</returns>
    public MightyXorFile DecryptFile(string ciphertextPath)
    {
        var decrypter = new Decrypter(_settings, ciphertextPath, _keyPath);
        return decrypter.Decrypt();
    }
}