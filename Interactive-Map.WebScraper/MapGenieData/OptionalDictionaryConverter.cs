using Newtonsoft.Json;

namespace Interactive_Map.WebScraper.MapGenieData;

public class OptionalDictionaryConverter<TKey, TValue> : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(Dictionary<TKey, TValue>);
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        try
        {
            if (reader.TokenType == JsonToken.StartObject)
            {
                // Deserialize a valid dictionary
                return serializer.Deserialize<Dictionary<TKey, TValue>>(reader);
            }
            else if (reader.TokenType == JsonToken.StartArray)
            {
                // Skip array and return an empty dictionary
                reader.Skip();
                return new Dictionary<TKey, TValue>();
            }
            else
            {
                // Handle other token types
                return new Dictionary<TKey, TValue>();
            }
        }
        catch
        {
            // Handle unexpected errors gracefully
            return new Dictionary<TKey, TValue>();
        }
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        serializer.Serialize(writer, value);
    }
}