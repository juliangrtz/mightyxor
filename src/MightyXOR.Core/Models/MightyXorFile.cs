using MightyXOR.Common.Exceptions;
using MightyXOR.Common.Logging;
using MightyXOR.Common.Utility;
using JsonSerializer = MightyXOR.Common.Serialization.JsonSerializer;

namespace MightyXOR.Core.Models;

/// <summary>
/// A serializable MightyXOR file used to persist various data.
/// Along with the file content itself, a header containing metadata is stored.
/// An MightyXorFile can represent a key or a ciphertext, for instance.
/// </summary>
[Serializable]
public class MightyXorFile
{
    /// <summary>
    /// Stores metadata of the encrypted file.
    /// </summary>
    public MightyXorFileHeader? Header { get; }

    /// <summary>
    /// The file content.
    /// </summary>
    public byte[] Content { get; }

    public MightyXorFile(MightyXorFileHeader? header, byte[] content)
    {
        Header = header;
        Content = content;
    }

    /// <summary>
    /// Compares the header MD5 hash with the actual MD5 hash of the <see cref="Content"/>.
    /// </summary>
    /// <exception cref="HashMismatchException"></exception>
    public bool CompareHashes()
    {
        if (Header == null)
            return true;

        var headerHash = Header.Md5Hash;
        var actualHash = new HashUtil(HashType.MD5).GenerateHash(Content);

        return headerHash.SequenceEqual(actualHash);
    }

    /// <summary>
    /// Saves the <see cref="Content"/> and restores its metadata.
    /// It is stored in the directory MightyXOR runs in.
    /// </summary>
    public void PersistContent(string path)
    {
        try
        {
            // Write the file content
            File.WriteAllBytes(path, Content);

            if (Header == null)
                return;

            // Unset read-only flag
            var attributes = File.GetAttributes(path);
            if ((attributes & FileAttributes.ReadOnly) != 0)
            {
                File.SetAttributes(path, attributes & ~FileAttributes.ReadOnly);
            }

            if (Header.ReadOnly)
                File.SetAttributes(path, FileAttributes.ReadOnly);

            File.SetCreationTime(path, Header.CreationTime);
            File.SetCreationTimeUtc(path, Header.CreationTimeUtc);
            File.SetLastAccessTime(path, Header.LastAccessTime);
            File.SetLastAccessTimeUtc(path, Header.LastAccessTimeUtc);
            File.SetLastWriteTime(path, Header.LastWriteTime);
            File.SetLastWriteTimeUtc(path, Header.LastWriteTimeUtc);
        }
        catch (Exception exception)
        {
            Log($"Persisting failed: {exception}\n Aborting...", LogType.Error);
        }
    }

    public override string ToString()
        => new JsonSerializer().SerializeObject(this);

    protected bool Equals(MightyXorFile other)
    {
        return Header == null ? Content.SequenceEqual(other.Content)
                              : Header.Equals(other.Header) && Content.SequenceEqual(other.Content);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        return obj.GetType() == this.GetType() && Equals((MightyXorFile)obj);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Header, Content);
    }
}