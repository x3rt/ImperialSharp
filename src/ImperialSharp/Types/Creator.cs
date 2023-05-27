namespace ImperialSharp.Types;

using Newtonsoft.Json;

public class Creator
{
    [JsonProperty("id")] public string Id { get; protected set; } = string.Empty;
    [JsonProperty("documents_made")] public int DocumentsMade { get; protected set; }
    [JsonProperty("username")] public string Username { get; protected set; } = string.Empty;
    [JsonProperty("flags")] public int Flags { get; protected set; }
    [JsonProperty("icon")] public string? Icon { get; protected set; }

    /// <summary>
    /// Default constructor.
    /// </summary>
    public Creator()
    {
    }

    /// <summary>
    /// Constructor for a creator. Used when listing Editors.
    /// </summary>
    /// <param name="username">The username of the creator.</param>
    public Creator(string username)
    {
        Username = username;
    }

    /// <summary>
    /// Constructor for a creator.
    /// </summary>
    /// <param name="id">The ID of the creator.</param>
    /// <param name="documentsMade">The number of documents the creator has made.</param>
    /// <param name="username">The username of the creator.</param>
    /// <param name="flags">The flags of the creator.</param>
    /// <param name="icon">The icon of the creator.</param>
    public Creator(string id, int documentsMade, string username, int flags, string? icon)
    {
        Id = id;
        DocumentsMade = documentsMade;
        Username = username;
        Flags = flags;
        Icon = icon;
    }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}