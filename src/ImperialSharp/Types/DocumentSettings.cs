using Newtonsoft.Json;

namespace ImperialSharp.Types;

public class DocumentSettings
{
    [JsonProperty("language")] public string Language { get; set; } = null!;
    [JsonProperty("image_embed")] public bool ImageEmbed { get; set; }
    [JsonProperty("instant_delete")] public bool InstantDelete { get; set; }
    [JsonProperty("encrypted")] public bool Encrypted { get; set; }
    [JsonProperty("password")] public string? Password { get; set; }
    [JsonProperty("public")] public bool Public { get; set; }
    [JsonProperty("editors")] public Creator[] Editors { get; set; } = null!;
}