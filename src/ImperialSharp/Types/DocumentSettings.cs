using Newtonsoft.Json;

namespace ImperialSharp.Types;

public class DocumentSettings
{
    [JsonProperty("language")] public string Language { get; set; } = "auto";
    [JsonProperty("image_embed")] public bool ImageEmbed { get; set; }
    [JsonProperty("instant_delete")] public bool InstantDelete { get; set; }
    [JsonProperty("encrypted")] public bool Encrypted { get; set; }
    [JsonProperty("password")] public string Password { private get; set; } = string.Empty;
    [JsonProperty("public")] public bool Public { get; set; }
    [JsonProperty("editors")] public Creator[] Editors { get; set; } = Array.Empty<Creator>();
}