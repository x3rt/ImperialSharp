using Newtonsoft.Json;

namespace ImperialSharp.Types;

public class Timestamps
{
    [JsonProperty("creation")] public DateTime Creation { get; set; }
    [JsonProperty("expiration")] public DateTime? Expiration { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}