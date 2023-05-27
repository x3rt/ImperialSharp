namespace ImperialSharp.Types;

using Newtonsoft.Json;

public class Creator
{
    [JsonProperty("id")] public string Id { get; set; } = null!;
    [JsonProperty("documents_made")] public int DocumentsMade { get; set; }
    [JsonProperty("username")] public string Username { get; set; } = null!;
    [JsonProperty("flags")] public int Flags { get; set; }
    [JsonProperty("icon")] public string? Icon { get; set; }
}