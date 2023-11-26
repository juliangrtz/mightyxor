using Amgine.Common.Serialization.Converters;
using Newtonsoft.Json;
using JsonSerializer = Amgine.Common.Serialization.JsonSerializer;

namespace Amgine.Core.Models;

/// <summary>
/// Stores metadata of an <see cref="AmgineFile"/>.
/// Can be considered as a wrapper class of <see cref="FileInfo"/> including a <see cref="Md5Hash"/>.
/// </summary>
[Serializable]
public class AmgineFileHeader
{
    /// <summary>
    /// The approximate size of a file header in bytes.
    /// </summary>
    public const int ApproximateHeaderSize = 400;

    /// <summary>
    /// The name of the file, excluding the extension.
    /// </summary>
    public string Name { get; init; } = string.Empty;

    /// <summary>
    /// The extension of the file, e.g. ".xlsx"
    /// </summary>
    public string Extension { get; init; } = string.Empty;

    /// <summary>
    /// The file length in bytes.
    /// </summary>
    public long Length { get; init; }

    /// <summary>
    /// Determines if the file is read-only.
    /// </summary>
    public bool ReadOnly { get; init; }

    /*
     * Time information
     */

    [JsonConverter(typeof(DateTimeTickConverter))]
    public DateTime CreationTime { get; init; }

    [JsonConverter(typeof(DateTimeTickConverter))]
    public DateTime CreationTimeUtc { get; init; }

    [JsonConverter(typeof(DateTimeTickConverter))]
    public DateTime LastAccessTime { get; init; }

    [JsonConverter(typeof(DateTimeTickConverter))]
    public DateTime LastAccessTimeUtc { get; init; }

    [JsonConverter(typeof(DateTimeTickConverter))]
    public DateTime LastWriteTime { get; init; }

    [JsonConverter(typeof(DateTimeTickConverter))]
    public DateTime LastWriteTimeUtc { get; init; }

    /// <summary>
    /// An MD5 md5Hash of the plaintext file.
    /// </summary>
    [JsonConverter(typeof(ByteArrayConverter))]
    public byte[] Md5Hash { get; init; } = Array.Empty<byte>();

    /// <summary>
    /// Default constructor is needed for deserialization.
    /// </summary>
    public AmgineFileHeader()
    {
    }

    /// <summary>
    /// Constructs a header with a <see cref="FileInfo"/>.
    /// Merely syntactic sugar.
    /// </summary>
    /// <param name="fileInfo">File info containing metadata</param>
    /// <param name="md5Hash">The MD5 hash of the file</param>
    public AmgineFileHeader(FileInfo fileInfo, byte[] md5Hash)
    {
        Name = fileInfo.Name;
        Extension = fileInfo.Extension;
        Length = fileInfo.Length;
        CreationTime = fileInfo.CreationTime;
        CreationTimeUtc = fileInfo.CreationTimeUtc;
        LastAccessTime = fileInfo.LastAccessTime;
        LastAccessTimeUtc = fileInfo.LastAccessTimeUtc;
        LastWriteTime = fileInfo.LastWriteTime;
        LastWriteTimeUtc = fileInfo.LastWriteTimeUtc;
        Md5Hash = md5Hash;
    }

    public override string ToString()
        => new JsonSerializer().SerializeObject(this);

    protected bool Equals(AmgineFileHeader other)
    {
        return Name.Equals(other.Name) &&
               Extension.Equals(other.Extension) &&
               Length == other.Length &&
               ReadOnly == other.ReadOnly &&
               CreationTime.Equals(other.CreationTime) &&
               CreationTimeUtc.Equals(other.CreationTimeUtc) &&
               LastAccessTime.Equals(other.LastAccessTime) &&
               LastAccessTimeUtc.Equals(other.LastAccessTimeUtc) &&
               LastWriteTime.Equals(other.LastWriteTime) &&
               LastWriteTimeUtc.Equals(other.LastWriteTimeUtc) &&
               Md5Hash.SequenceEqual(other.Md5Hash);
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((AmgineFileHeader)obj);
    }

    public override int GetHashCode()
    {
        var hashCode = new HashCode();
        hashCode.Add(Name);
        hashCode.Add(Extension);
        hashCode.Add(Length);
        hashCode.Add(ReadOnly);
        hashCode.Add(CreationTime);
        hashCode.Add(CreationTimeUtc);
        hashCode.Add(LastAccessTime);
        hashCode.Add(LastAccessTimeUtc);
        hashCode.Add(LastWriteTime);
        hashCode.Add(LastWriteTimeUtc);
        hashCode.Add(Md5Hash);
        return hashCode.ToHashCode();
    }
}