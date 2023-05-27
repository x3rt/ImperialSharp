using Newtonsoft.Json;

namespace ImperialSharp;

public class Data
{
    [JsonProperty("id")] public string Id { get; set; } = null!;
    [JsonProperty("content")] public string Content { get; set; } = null!;
    [JsonProperty("creator")] public Creator? Creator { get; set; }
    [JsonProperty("views")] public int Views { get; set; }
    [JsonProperty("gist_url")] public string? GistUrl { get; set; }
    [JsonProperty("timestamps")] public Timestamps Timestamps { get; set; } = null!;
    [JsonProperty("settings")] public DocumentSettings Settings { get; set; } = null!;
    [JsonProperty("links")] public Links Links { get; set; } = null!;

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}