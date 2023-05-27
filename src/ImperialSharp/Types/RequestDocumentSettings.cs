using Newtonsoft.Json;

namespace ImperialSharp.Types;

public class RequestDocumentSettings
{
    [JsonProperty("language")] public string? Language { get; set; }
    [JsonProperty("image_embed")] public bool? ImageEmbed { get; set; }
    [JsonProperty("instant_delete")] public bool? InstantDelete { get; set; }
    [JsonProperty("encrypted")] public bool? Encrypted { get; set; }
    [JsonProperty("password")] public string? Password { get; set; }
    [JsonProperty("public")] public bool? Public { get; set; }
    [JsonProperty("editors")] public string[]? Editors { get; set; }
}