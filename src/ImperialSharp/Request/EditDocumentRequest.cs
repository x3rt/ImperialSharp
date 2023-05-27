using ImperialSharp.Types;
using Newtonsoft.Json;

namespace ImperialSharp.Request;

/// <summary>
/// Represents a request to edit a document.
/// </summary>
public class EditDocumentRequest
{
    /// <summary>
    /// The ID of the document to edit. [Required]
    /// </summary>
    [JsonProperty("id")]
    [JsonRequired]
    public string Id { get; set; } = null!;

    /// <summary>
    /// The new content of the document. [Optional]
    /// </summary>
    [JsonProperty("content")]
    public string? Content { get; set; }

    /// <summary>
    /// The new settings of the document. [Optional]
    /// </summary>
    [JsonProperty("settings")]
    public DocumentSettings? Settings
    {
        get => _settings ?? new DocumentSettings();
        set => _settings = value;
    }

    private DocumentSettings? _settings;

    /// <summary>
    /// Default constructor
    /// </summary>
    public EditDocumentRequest()
    {
    }

    /// <summary>
    /// Constructor for a request to edit a document.
    /// </summary>
    /// <param name="id">ID of the document to edit. [Required]</param>
    /// <param name="content">The new content of the document. Null to keep current content. [Optional]</param>
    /// <param name="settings">The new settings of the document. Null to keep current settings. [Optional]</param>
    public EditDocumentRequest(string id, string? content = null, DocumentSettings? settings = null)
    {
        Id = id;
        Content = content;
        Settings = settings;
    }

    /// <summary>
    /// Constructor for a request to edit a document.
    /// </summary>
    /// <param name="id">ID of the document to edit. [Required]</param>
    /// <param name="settings">The new settings of the document. Null to keep current settings. [Optional]</param>
    public EditDocumentRequest(string id, DocumentSettings settings)
    {
        Id = id;
        Settings = settings;
    }

    /// <summary>
    /// Sets the content of the document.
    /// </summary>
    /// <param name="content">The content to be set.</param>
    /// <returns>The current instance of <see cref="EditDocumentRequest"/>.</returns>
    public EditDocumentRequest WithContent(string content)
    {
        Content = content;
        return this;
    }

    /// <summary>
    /// Sets the settings of the document.
    /// </summary>
    /// <param name="settings">The settings to be set.</param>
    /// <returns>The current instance of <see cref="EditDocumentRequest"/>.</returns>
    public EditDocumentRequest WithSettings(DocumentSettings settings)
    {
        Settings = settings;
        return this;
    }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}