using ImperialSharp.Converters;
using Newtonsoft.Json;

namespace ImperialSharp;

public class DocumentSettings
{
    [JsonProperty("language")] public string Language { get; set; } = "auto";
    [JsonProperty("image_embed")] public bool ImageEmbed { get; set; }
    [JsonProperty("instant_delete")] public bool InstantDelete { get; set; }
    [JsonProperty("encrypted")] public bool Encrypted { get; set; }
    [JsonProperty("password")] public string Password { private get; set; } = string.Empty;
    [JsonProperty("public")] public bool Public { get; set; }

    [JsonProperty("editors", ItemConverterType = typeof(CreatorConverter))]
    public Creator[] Editors { get; set; } = Array.Empty<Creator>();

    /// <summary>
    /// Sets the language of the document.
    /// </summary>
    /// <param name="language">The language to set.</param>
    /// <returns>The current instance of <see cref="DocumentSettings"/>.</returns>
    public DocumentSettings WithLanguage(string language)
    {
        Language = language;
        return this;
    }

    /// <summary>
    /// Sets whether or not to embed images.
    /// </summary>
    /// <param name="imageEmbed">Whether or not to embed images.</param>
    /// <returns>The current instance of <see cref="DocumentSettings"/>.</returns>
    public DocumentSettings WithImageEmbed(bool imageEmbed = true)
    {
        ImageEmbed = imageEmbed;
        return this;
    }

    /// <summary>
    /// Sets whether or not to enable instant delete.
    /// </summary>
    /// <param name="instantDelete">Whether or not to enable instant delete.</param>
    /// <returns>The current instance of <see cref="DocumentSettings"/>.</returns>
    public DocumentSettings WithInstantDelete(bool instantDelete = true)
    {
        InstantDelete = instantDelete;
        return this;
    }

    /// <summary>
    /// Sets whether or not to encrypt the document.
    /// </summary>
    /// <param name="encrypted">Whether or not to encrypt the document.</param>
    /// <returns>The current instance of <see cref="DocumentSettings"/>.</returns>
    public DocumentSettings WithEncryption(bool encrypted = true)
    {
        Encrypted = encrypted;
        return this;
    }

    /// <summary>
    /// Sets the password of the document.
    /// </summary>
    /// <param name="password">The password to set.</param>
    /// <returns>The current instance of <see cref="DocumentSettings"/>.</returns>
    public DocumentSettings WithPassword(string password)
    {
        Password = password;
        return this;
    }

    /// <summary>
    /// Sets whether or not the document is public.
    /// </summary>
    /// <param name="isPublic">Whether or not the document is public.</param>
    /// <returns>The current instance of <see cref="DocumentSettings"/>.</returns>
    public DocumentSettings AsPublic(bool isPublic = true)
    {
        Public = isPublic;
        return this;
    }

    /// <summary>
    /// Sets the editors of the document.
    /// </summary>
    /// <param name="editors">The editors to set.</param>
    /// <returns>The current instance of <see cref="DocumentSettings"/>.</returns>
    public DocumentSettings WithEditors(params Creator[] editors)
    {
        Editors = editors;
        return this;
    }

    /// <summary>
    /// Sets the editors of the document.
    /// </summary>
    /// <param name="editors">The editors to set.</param>
    /// <returns>The current instance of <see cref="DocumentSettings"/>.</returns>
    public DocumentSettings WithEditors(IEnumerable<Creator> editors)
    {
        Editors = editors.ToArray();
        return this;
    }

    /// <summary>
    /// Sets the editors of the document.
    /// </summary>
    /// <param name="editors">The editors to set.</param>
    /// <returns>The current instance of <see cref="DocumentSettings"/>.</returns>
    public DocumentSettings WithEditors(params string[] editors)
    {
        Editors = editors.Select(x => new Creator(x)).ToArray();
        return this;
    }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}