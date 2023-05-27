using Newtonsoft.Json;

namespace ImperialSharp.Types;

public class Error
{
    [JsonProperty("error")] public string Message { get; set; } = string.Empty;

    public override string ToString()
    {
        return Message;
    }
}