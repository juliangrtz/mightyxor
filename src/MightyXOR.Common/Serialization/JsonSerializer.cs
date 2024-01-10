using MightyXOR.Common.Exceptions;
using ErrorEventArgs = Newtonsoft.Json.Serialization.ErrorEventArgs;

namespace MightyXOR.Common.Serialization;

/// <summary>
/// Serializes and deserializes JSON data.
/// </summary>
public class JsonSerializer
{
    private readonly JsonSerializerSettings _serializerSettings;

    /// <summary>
    /// Constructs the JSON serializer with default serialization settings.
    /// </summary>
    public JsonSerializer()
    {
        _serializerSettings = new JsonSerializerSettings()
        {
            Error = HandleSerializationError,
            Formatting = Formatting.Indented,
            NullValueHandling = NullValueHandling.Include,
        };
    }

    /// <summary>
    /// Constructs the JSON serializer with given serialization settings.
    /// </summary>
    /// <param name="settings">Serialization settings to use</param>
    public JsonSerializer(JsonSerializerSettings settings)
        => _serializerSettings = settings;

    /// <summary>
    /// Serializes an object to a JSON string.
    /// </summary>
    /// <param name="obj">Object to serialize</param>
    /// <returns>Serialized object</returns>
    public string SerializeObject(object obj)
        => JsonConvert.SerializeObject(obj, _serializerSettings);

    /// <summary>
    /// Deserializes a JSON string to an object.
    /// </summary>
    /// <typeparam name="T">Type of the object</typeparam>
    /// <param name="str">JSON string</param>
    /// <returns>Deserialized object</returns>
    public T? DeserializeObject<T>(string str)
        => JsonConvert.DeserializeObject<T>(str, _serializerSettings);

    private static void HandleSerializationError(object? sender, ErrorEventArgs e)
    {
        var ctx = e.ErrorContext;
        throw new SerializationException($"Failed to JSON-serialize an object of type {e.CurrentObject?.GetType()}. " +
                                         $"Error: {ctx.Error}");
    }
}