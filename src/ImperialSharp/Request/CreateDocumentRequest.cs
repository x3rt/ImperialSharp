using Newtonsoft.Json;

namespace ImperialSharp.Request;

/// <summary>
/// Represents a request to create a document.
/// </summary>
public class CreateDocumentRequest
{
    /// <summary>
    /// The content of the document. [Required]
    /// </summary>
    [JsonProperty("content")]
    [JsonRequired]
    public string Content { get; set; } = null!;

    /// <summary>
    /// The settings of the document. [Optional]
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
    public CreateDocumentRequest()
    {
    }

    /// <summary>
    /// Constructor for a request to create a document.
    /// </summary>
    /// <param name="content">The content of the document. [Required]</param>
    /// <param name="settings">The settings of the document. [Optional]</param>
    public CreateDocumentRequest(string content, DocumentSettings? settings = null)
    {
        Content = content;
        Settings = settings;
    }

    /// <summary>
    /// Sets the content of the document.
    /// </summary>
    /// <param name="content">The content to be set.</param>
    /// <returns>The current instance of <see cref="CreateDocumentRequest"/>.</returns>
    public CreateDocumentRequest WithContent(string content)
    {
        Content = content;
        return this;
    }

    /// <summary>
    /// Sets the settings of the document.
    /// </summary>
    /// <param name="settings">The settings to be set.</param>
    /// <returns>The current instance of <see cref="CreateDocumentRequest"/>.</returns>
    public CreateDocumentRequest WithSettings(DocumentSettings settings)
    {
        Settings = settings;
        return this;
    }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}