using System.Formats.Asn1;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;

namespace ImperialSharp.Clients;

public class BaseClient
{
    private string _baseUrl = "https://api.imperialb.in/";
    private string _version = "v1";
    private readonly HttpClient _httpClient;
    private string? _apiKey = null;

    public string BaseUrl
    {
        get => _baseUrl;
        set => _baseUrl = value;
    }

    public string Version
    {
        get => _version;
        set => _version = value;
    }

    public string BaseEndpoint => $"{BaseUrl}{Version}/";


    /// <summary>
    ///  Default constructor
    /// </summary>
    public BaseClient()
    {
        _httpClient = new HttpClient();
        _httpClient.DefaultRequestHeaders.Add("User-Agent", "ImperialSharp");
        _httpClient.DefaultRequestHeaders.Add("Content-Type", "application/json");
        _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
    }

    /// <summary>
    /// Constructor for a client with a custom HttpClient
    /// </summary>
    /// <param name="httpClient">The HttpClient to be used for requests.</param>
    public BaseClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    /// <summary>
    /// Constructor for a client with an API key
    /// </summary>
    /// <param name="apiKey">The API key to be used for requests.</param>
    public BaseClient(string apiKey) : this()
    {
        _apiKey = apiKey;
    }

    /// <summary>
    /// Constructor for a client with an API key and a custom HttpClient
    /// </summary>
    /// <param name="apiKey">The API key to be used for requests.</param>
    /// <param name="httpClient">The HttpClient to be used for requests.</param>
    public BaseClient(string apiKey, HttpClient httpClient) : this(httpClient)
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
        _httpClient.DefaultRequestHeaders.Authorization =
            _apiKey != null ? new AuthenticationHeaderValue("", _apiKey) : null;
    }

    /// <summary>
    /// Sends a GET request to the specified endpoint.
    /// </summary>
    /// <param name="endpoint">The endpoint to send the request to.</param>
    /// <typeparam name="T">The type of the response.</typeparam>
    /// <returns>The response from the API.</returns>
    public async Task<T?> GetAsync<T>(string endpoint)
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
    public async Task<T?> PostAsync<T>(string endpoint, object? body)
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
    public async Task<T?> PostAsync<T>(string endpoint, string body)
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
    public async Task<T?> PatchAsync<T>(string endpoint, object? body)
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
    public async Task<T?> PatchAsync<T>(string endpoint, string body)
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
    public async Task<T?> DeleteAsync<T>(string endpoint)
    {
        SetAuthorizationHeader();
        var response = await _httpClient.DeleteAsync($"{BaseEndpoint}{endpoint}");
        var responseString = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<T>(responseString);
    }
}