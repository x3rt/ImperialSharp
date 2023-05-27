using Newtonsoft.Json;

namespace ImperialSharp.Types;

public class Error
{
    [JsonProperty("message")] public string Message { get; set; } = string.Empty;
    
    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}