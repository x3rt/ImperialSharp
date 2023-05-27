using System.Text;
using Newtonsoft.Json;

namespace ImperialSharp.Clients;

public abstract class BaseClient : IDisposable
{
    private readonly HttpClient _httpClient;
    private string? _apiKey;

    public string BaseUrl { get; set; } = "https://api.imperialb.in/";

    public string Version { get; set; } = "v1";

    private string BaseEndpoint => $"{BaseUrl}{Version}/";

    /// <summary>
    /// Default constructor
    /// </summary>
    protected BaseClient()
    {
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Add("User-Agent", "ImperialSharp");
    }

    /// <summary>
    /// Constructor for a client with a custom HttpClient
    /// </summary>
    /// <param name="httpClient">The HttpClient to be used for requests.</param>
    protected BaseClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    /// <summary>
    /// Constructor for a client with an API key
    /// </summary>
    /// <param name="apiKey">The API key to be used for requests.</param>
    protected BaseClient(string apiKey) : this()
    {
        _apiKey = apiKey;
    }

    /// <summary>
    /// Constructor for a client with an API key and a custom HttpClient
    /// </summary>
    /// <param name="apiKey">The API key to be used for requests.</param>
    /// <param name="httpClient">The HttpClient to be used for requests.</param>
    protected BaseClient(string apiKey, HttpClient httpClient) : this(httpClient)
    {
        _apiKey = apiKey;
    }

    /// <summary>
    /// Sets the API key for the client.
    /// </summary>
    /// <param name="apiKey">The API key to be set.</param>
    /// <returns>The current client to be chained.</returns>
    public BaseClient WithApiKey(string apiKey)
    {
        _apiKey = apiKey;
        return this;
    }

    /// <summary>
    /// Sets Authorization header for the current HttpClient.
    /// </summary>
    private void SetAuthorizationHeader()
    {
        _httpClient.DefaultRequestHeaders.Remove("Authorization");
        if (_apiKey is not null)
        {
            _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", _apiKey);
        }
    }

    /// <summary>
    /// Sends a GET request to the specified endpoint.
    /// </summary>
    /// <param name="endpoint">The endpoint to send the request to.</param>
    /// <typeparam name="T">The type of the response.</typeparam>
    /// <returns>The response from the API.</returns>
    protected async Task<T?> GetAsync<T>(string endpoint)
    {
        SetAuthorizationHeader();
        var response = await _httpClient.GetAsync($"{BaseEndpoint}{endpoint}");
        var responseString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(responseString);
    }

    /// <summary>
    /// Sends a POST request to the specified endpoint.
    /// </summary>
    /// <param name="endpoint">The endpoint to send the request to.</param>
    /// <param name="body">The body of the request.</param>
    /// <typeparam name="T">The type of the response.</typeparam>
    /// <returns>The response from the API.</returns>
    protected async Task<T?> PostAsync<T>(string endpoint, object? body)
    {
        SetAuthorizationHeader();
        var response = await _httpClient.PostAsync($"{BaseEndpoint}{endpoint}",
            new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json"));
        var responseString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(responseString);
    }

    /// <summary>
    /// Sends a POST request to the specified endpoint.
    /// </summary>
    /// <param name="endpoint">The endpoint to send the request to.</param>
    /// <param name="body">The body of the request.</param>
    /// <typeparam name="T">The type of the response.</typeparam>
    /// <returns>The response from the API.</returns>
    protected async Task<T?> PostAsync<T>(string endpoint, string body)
    {
        SetAuthorizationHeader();
        var response = await _httpClient.PostAsync($"{BaseEndpoint}{endpoint}",
            new StringContent(body, Encoding.UTF8, "application/json"));
        var responseString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(responseString);
    }

    /// <summary>
    /// Sends a PATCH request to the specified endpoint.
    /// </summary>
    /// <param name="endpoint">The endpoint to send the request to.</param>
    /// <param name="body">The body of the request.</param>
    /// <typeparam name="T">The type of the response.</typeparam>
    /// <returns>The response from the API.</returns>
    protected async Task<T?> PatchAsync<T>(string endpoint, object? body)
    {
        SetAuthorizationHeader();
        var response = await _httpClient.PatchAsync($"{BaseEndpoint}{endpoint}",
            new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json"));
        var responseString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(responseString);
    }

    /// <summary>
    /// Sends a PATCH request to the specified endpoint.
    /// </summary>
    /// <param name="endpoint">The endpoint to send the request to.</param>
    /// <param name="body">The body of the request.</param>
    /// <typeparam name="T">The type of the response.</typeparam>
    /// <returns>The response from the API.</returns>
    protected async Task<T?> PatchAsync<T>(string endpoint, string body)
    {
        SetAuthorizationHeader();
        var response = await _httpClient.PatchAsync($"{BaseEndpoint}{endpoint}",
            new StringContent(body, Encoding.UTF8, "application/json"));
        var responseString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(responseString);
    }

    /// <summary>
    /// Sends a DELETE request to the specified endpoint.
    /// </summary>
    /// <param name="endpoint">The endpoint to send the request to.</param>
    /// <typeparam name="T">The type of the response.</typeparam>
    /// <returns>The response from the API.</returns>
    protected async Task<T?> DeleteAsync<T>(string endpoint)
    {
        SetAuthorizationHeader();
        var response = await _httpClient.DeleteAsync($"{BaseEndpoint}{endpoint}");
        var responseString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(responseString);
    }

    /// <summary>
    /// Sends a DELETE request to the specified endpoint.
    /// </summary>
    /// <param name="endpoint">The endpoint to send the request to.</param>
    /// <returns>The HttpResponseMessage</returns>
    protected async Task<HttpResponseMessage> DeleteAsyncWithResponse(string endpoint)
    {
        SetAuthorizationHeader();
        return await _httpClient.DeleteAsync($"{BaseEndpoint}{endpoint}");
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }
}