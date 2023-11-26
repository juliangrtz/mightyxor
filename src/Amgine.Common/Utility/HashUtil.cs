using Amgine.Common.Logging;
using System.Security.Cryptography;

namespace Amgine.Common.Utility;

/// <summary>
/// Serves as a utility class to compute hashes.
/// Needed to verify file integrity.
/// </summary>
public class HashUtil
{
    private readonly HashAlgorithm _hashAlgorithm;

    public HashUtil(HashType hashType)
    {
        switch (hashType)
        {
            case HashType.MD5:
                _hashAlgorithm = MD5.Create();
                break;

            case HashType.SHA1:
                _hashAlgorithm = SHA1.Create();
                break;

            case HashType.SHA256:
                _hashAlgorithm = SHA256.Create();
                break;

            default:
                Logger.Log($"Unknown hash type provided ({hashType}). Resorting to MD5.", LogType.Warning);
                goto case HashType.MD5;
        }
    }

    /// <summary>
    /// Generates a hash based off the provided <see cref="HashType"/>.
    /// </summary>
    /// <param name="data">Data to be hashed</param>
    public byte[] GenerateHash(byte[] data)
        => _hashAlgorithm.ComputeHash(new MemoryStream(data));

    /// <summary>
    /// Generates a hash based off the provided <see cref="HashType"/>.
    /// </summary>
    /// <param name="filePath">File to be hashed</param>
    public byte[] GenerateHash(string filePath)
        => _hashAlgorithm.ComputeHash(File.OpenRead(filePath));
}