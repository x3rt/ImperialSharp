using ImperialSharp.Request;
using ImperialSharp.Response;
using ImperialSharp.Types;
using Newtonsoft.Json;

namespace ImperialSharp.Clients;

public class ApiClient : BaseClient
{
    #region Constructors

    /// <summary>
    /// Default constructor
    /// </summary>
    public ApiClient() : base()
    {
    }

    /// <summary>
    /// Constructor for a client with a custom HttpClient
    /// </summary>
    /// <param name="httpClient">The HttpClient to be used for requests.</param>
    public ApiClient(HttpClient httpClient) : base(httpClient)
    {
    }

    /// <summary>
    /// Constructor for a client with an API key
    /// </summary>
    /// <param name="apiKey">The API key to be used for requests.</param>
    public ApiClient(string apiKey) : base(apiKey)
    {
    }

    /// <summary>
    /// Constructor for a client with an API key and a custom HttpClient
    /// </summary>
    /// <param name="apiKey">The API key to be used for requests.</param>
    /// <param name="httpClient">The HttpClient to be used for requests.</param>
    public ApiClient(string apiKey, HttpClient httpClient) : base(apiKey, httpClient)
    {
    }

    #endregion

    #region Methods

    /// <summary>
    /// Creates a document.
    /// </summary>
    /// <param name="request">The document request object.</param>
    /// <returns>The API response.</returns>
    /// <exception cref="NullReferenceException">Thrown when the response is null.</exception>
    public async Task<DocumentResponse> CreateDocumentAsync(CreateDocumentRequest request)
    {
        var response = await PostAsync<DocumentResponse>("document", request);
        return response ?? throw new NullReferenceException("Response was null");
    }

    /// <summary>
    /// Creates a document.
    /// </summary>
    /// <param name="content">Content of the document. [Required]</param>
    /// <param name="settings">Settings for the document. [Optional]</param>
    /// <returns>The API response.</returns>
    /// <exception cref="NullReferenceException">Thrown when the response is null.</exception>
    public async Task<DocumentResponse> CreateDocumentAsync(string content, RequestDocumentSettings? settings = null)
    {
        var request = new CreateDocumentRequest(content, settings);
        var response = await PostAsync<DocumentResponse>("document", request);
        return response ?? throw new NullReferenceException("Response was null");
    }

    /// <summary>
    /// Edits a document.
    /// </summary>
    /// <param name="id">The ID of the document to be edited.</param>
    /// <param name="content">The new content of the document. Null to keep current content. [Optional]</param>
    /// <param name="settings">The new settings of the document. Null to keep current settings. [Optional]</param>
    /// <returns>The API response.</returns>
    /// <exception cref="NullReferenceException">Thrown when the response is null.</exception>
    public async Task<DocumentResponse> EditDocumentAsync(string id, string content,
        RequestDocumentSettings? settings = null)
    {
        var request = new EditDocumentRequest(id, content, settings);
        var response = await PatchAsync<DocumentResponse>($"document", request);
        return response ?? throw new NullReferenceException("Response was null");
    }

    /// <summary>
    /// Edits a document.
    /// </summary>
    /// <param name="id">The ID of the document to be edited.</param>
    /// <param name="settings">The new settings of the document. Null to keep current settings. [Optional]</param>
    /// <returns>The API response.</returns>
    /// <exception cref="NullReferenceException">Thrown when the response is null.</exception>
    public async Task<DocumentResponse> EditDocumentAsync(string id, RequestDocumentSettings settings)
    {
        var request = new EditDocumentRequest(id, settings);
        var response = await PatchAsync<DocumentResponse>($"document", request);
        return response ?? throw new NullReferenceException("Response was null");
    }

    /// <summary>
    /// Edits a document.
    /// </summary>
    /// <param name="request">The document request object.</param>
    /// <returns>The API response.</returns>
    /// <exception cref="NullReferenceException">Thrown when the response is null.</exception>
    public async Task<DocumentResponse> EditDocumentAsync(EditDocumentRequest request)
    {
        var response = await PatchAsync<DocumentResponse>($"document", request);
        return response ?? throw new NullReferenceException("Response was null");
    }

    /// <summary>
    /// Gets a document.
    /// </summary>
    /// <param name="id">The ID of the document to be retrieved.</param>
    /// <returns>The API response.</returns>
    /// <exception cref="NullReferenceException">Thrown when the response is null.</exception>
    public async Task<DocumentResponse> GetDocumentAsync(string id)
    {
        var response = await GetAsync<DocumentResponse>($"document/{id}");
        return response ?? throw new NullReferenceException("Response was null");
    }

    /// <summary>
    /// Gets a document.
    /// </summary>
    /// <param name="id">The ID of the document to be retrieved.</param>
    /// <param name="password">The password of the document to be retrieved.</param>
    /// <returns>The API response.</returns>
    /// <exception cref="NullReferenceException">Thrown when the response is null.</exception>
    public async Task<DocumentResponse> GetDocumentAsync(string id, string password)
    {
        var response = await GetAsync<DocumentResponse>($"document/{id}?password={password}");
        return response ?? throw new NullReferenceException("Response was null");
    }

    /// <summary>
    /// Deletes a document.
    /// </summary>
    /// <param name="id">The ID of the document to be deleted.</param>
    /// <returns>The API response.</returns>
    public async Task<DocumentResponse> DeleteDocumentAsync(string id)
    {
        var response = await DeleteAsyncWithResponse($"document/{id}");
        var responseString = await response.Content.ReadAsStringAsync();
        var deserializedResponse = JsonConvert.DeserializeObject<DocumentResponse>(responseString);
        return deserializedResponse ?? new DocumentResponse(response.IsSuccessStatusCode);
    }

    #endregion
}