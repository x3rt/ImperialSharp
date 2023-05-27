using Newtonsoft.Json;

namespace ImperialSharp.Types;

public class Links
{
    [JsonProperty("formatted")] public string Formatted { get; set; } = string.Empty;
    [JsonProperty("raw")] public string Raw { get; set; } = string.Empty;

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}