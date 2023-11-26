using Amgine.Common.Logging;

namespace Amgine.Common.Serialization.Converters;

/// <summary>
/// A custom JSON/BSON connverter for byte arrays.
/// </summary>
public class ByteArrayConverter : JsonConverter
{
    /// <summary>
    /// Only byte arrays can be converted.
    /// </summary>
    public override bool CanConvert(Type objectType)
        => objectType == typeof(byte[]);

    /// <summary>
    /// Converts a byte array to its hexadecimal string representation.
    /// </summary>
    public override void WriteJson(JsonWriter writer, object? value, Newtonsoft.Json.JsonSerializer serializer)
    {
        if (value == null)
        {
            writer.WriteNull();
        }
        else
        {
            var array = value as byte[] ?? Array.Empty<byte>();
            writer.WriteValue(ByteArrayToHexString(array));
        }
    }

    /// <summary>
    /// Converts a hexadecimal string back to its byte array object.
    /// Adapted from <see href="https://stackoverflow.com/a/14335076/4350677"></see>
    /// </summary>
    public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, Newtonsoft.Json.JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.String)
        {
            var hexString = serializer.Deserialize<string>(reader);

            if (!string.IsNullOrEmpty(hexString) && (hexString.Length & 1) == 0)
            {
                var ret = new byte[hexString.Length / 2];
                for (var i = 0; i < ret.Length; i++)
                {
                    var high = ParseNibble(hexString[i * 2]);
                    var low = ParseNibble(hexString[i * 2 + 1]);
                    ret[i] = (byte)((high << 4) | low);
                }
                return ret;
            }
        }

        return Enumerable.Empty<byte>();
    }

    /// <summary>
    /// Efficient conversion from byte array to hexadecimal string.
    /// Taken from <see href="https://stackoverflow.com/a/14333437/4350677"></see>
    /// </summary>
    /// <param name="bytes">Bytes to convert</param>
    private static string ByteArrayToHexString(byte[] bytes)
    {
        // Use (55 + b + (((b-10)>>31)&-7)) instead of
        // (87 + b + (((b - 10) >> 31) & -39)) if uppercase is wanted.

        var chars = new char[bytes.Length * 2];
        for (var i = 0; i < bytes.Length; i++)
        {
            var b = bytes[i] >> 4;
            chars[i * 2] = (char)(87 + b + (((b - 10) >> 31) & -39)); // High nibble

            b = bytes[i] & 0xF;
            chars[i * 2 + 1] = (char)(87 + b + (((b - 10) >> 31) & -39)); // Low nibble
        }

        return new string(chars);
    }

    /// <summary>
    /// Converts a nibble (0–9 and A–F) to its respective integer value.
    /// </summary>
    /// <param name="c">The nibble</param>
    /// <exception cref="ArgumentException"></exception>
    private static int ParseNibble(char c)
    {
        unchecked
        {
            var i = (uint)(c - '0');

            if (i < 10)
                return (int)i;

            i = (c & ~0x20u) - 'A';

            if (i < 6)
                return (int)i + 10;

            Logger.Log($"Invalid nibble ({c})!", LogType.Warning);
            return 0;
        }
    }
}