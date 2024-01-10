namespace MightyXOR.Common.Serialization.Converters;

/// <summary>
/// Since we use BSON at places, we want to just store ticks to avoid losing precision.
/// By default BSON will use JSON ticks.
/// </summary>
public class DateTimeTickConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(DateTime) ||
               objectType == typeof(DateTime?) ||
               objectType == typeof(DateTimeOffset) ||
               objectType == typeof(DateTimeOffset?);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object? existingValue, Newtonsoft.Json.JsonSerializer serializer)
    {
        if (reader.TokenType != JsonToken.Integer && reader.TokenType != JsonToken.Date)
        {
            return null!;
        }

        DateTime dateTime;

        if (reader.TokenType == JsonToken.Date)
        {
            dateTime = (DateTime)(reader.Value ?? DateTime.Now);
        }
        else
        {
            var ticks = (long)(reader.Value ?? DateTime.Now);
            dateTime = new DateTime(ticks, DateTimeKind.Utc);
        }

        if (objectType == typeof(DateTime) || objectType == typeof(DateTime?))
        {
            return dateTime;
        }

        if (objectType == typeof(DateTimeOffset) || objectType == typeof(DateTimeOffset?))
        {
            return (DateTimeOffset)dateTime;
        }

        return null!;
    }

    public override void WriteJson(JsonWriter writer, object? value, Newtonsoft.Json.JsonSerializer serializer)
    {
        switch (value)
        {
            case DateTime dateTime:
                serializer.Serialize(writer, dateTime.Ticks);
                break;

            case DateTimeOffset dateTimeOffset:
                serializer.Serialize(writer, dateTimeOffset.UtcDateTime.Ticks);
                break;

            case null:
                return;
        }
    }
}