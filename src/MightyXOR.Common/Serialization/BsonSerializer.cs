using MightyXOR.Common.Exceptions;
using Newtonsoft.Json.Bson;
using ErrorEventArgs = Newtonsoft.Json.Serialization.ErrorEventArgs;

namespace MightyXOR.Common.Serialization;

/// <summary>
/// Serializes and deserializes BSON data.
/// </summary>
public class BsonSerializer
{
    private MemoryStream _stream;

    /// <summary>
    /// Constructs the BSON serializer with default serialization settings.
    /// </summary>
    public BsonSerializer()
    {
        _stream = new MemoryStream();

        JsonConvert.DefaultSettings = () => new JsonSerializerSettings
        {
            Error = HandleSerializationError,
            Formatting = Formatting.Indented,
            NullValueHandling = NullValueHandling.Include,
        };
    }

    /// <summary>
    /// Constructs the BSON serializer with custom serialization settings.
    /// </summary>
    public BsonSerializer(JsonSerializerSettings settings)
    {
        _stream = new MemoryStream();
        JsonConvert.DefaultSettings = () => settings;
    }

    /// <summary>
    /// Serializes an object to a BSON byte array
    /// </summary>
    /// <param name="obj">Object to serialize</param>
    /// <returns>Serialized object</returns>
    public IEnumerable<byte> SerializeObject(object obj)
    {
        _stream = new MemoryStream();
        using var writer = new BsonDataWriter(_stream);
        var serializer = new Newtonsoft.Json.JsonSerializer();

        serializer.Serialize(writer, obj);

        return _stream.ToArray();
    }

    /// <summary>
    /// Deserializes a BSON byte array to an object.
    /// </summary>
    /// <typeparam name="T">Type of the object</typeparam>
    /// <param name="data">BSON byte array</param>
    /// <returns>Deserialized object</returns>
    public T? DeserializeObject<T>(byte[]? data)
    {
        if (data != null)
        {
            _stream = new MemoryStream(data);
            using var reader = new BsonDataReader(_stream);
            var serializer = new Newtonsoft.Json.JsonSerializer();

            return serializer.Deserialize<T>(reader);
        }

        throw new SerializationException("Cannot deserialize null.");
    }

    private static void HandleSerializationError(object? sender, ErrorEventArgs e)
    {
        var ctx = e.ErrorContext;
        throw new SerializationException($"Failed to BSON-serialize an object of type {e.CurrentObject?.GetType()}. " +
                                         $"Error: {ctx.Error}");
    }
}