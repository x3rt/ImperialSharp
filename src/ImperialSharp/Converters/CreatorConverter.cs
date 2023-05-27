using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ImperialSharp.Converters;

internal class CreatorConverter : JsonConverter<Creator>
{
    public override void WriteJson(JsonWriter writer, Creator? value, JsonSerializer serializer)
    {
        if (value == null)
        {
            writer.WriteNull();
            return;
        }

        writer.WriteValue(value.Username);
    }

    public override Creator? ReadJson(JsonReader reader, Type objectType, Creator? existingValue, bool hasExistingValue,
        JsonSerializer serializer)
    {
        var jObject = serializer.Deserialize<JObject>(reader);

        if (jObject == null)
            return null;

        var id = jObject["id"]?.Value<string>();
        var documentsMade = jObject["documents_made"]?.Value<int>();
        var username = jObject["username"]?.Value<string>();
        var flags = jObject["flags"]?.Value<int>();
        var icon = jObject["icon"]?.Value<string>();

        if (id == null || documentsMade == null || username == null || flags == null)
            return null;

        return new Creator(id, documentsMade.Value, username, flags.Value, icon);
    }
}