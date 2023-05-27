using Newtonsoft.Json;

namespace ImperialSharp.Response;

/// <summary>
/// Represents a response from the API.
/// </summary>
public class ApiResponse
{
    /// <summary>
    /// Whether the request was successful or not.
    /// </summary>
    [JsonProperty("success")]
    public bool Success { get; set; }

    /// <summary>
    /// The data returned from the API.
    /// Null if the request was not successful.
    /// </summary>
    [JsonProperty("data")]
    public Data? Data { get; set; }

    /// <summary>
    /// The error returned from the API.
    /// Null if the request was successful.
    /// </summary>

    [JsonProperty("error")]
    public Error? Error { get; set; }

    /// <summary>
    /// Constructor for a response from the API.
    /// </summary>
    /// <param name="success">Whether the request was successful or not.</param>
    /// <param name="data">The data returned from the API. Null if the request was not successful.</param>
    /// <param name="error">The error returned from the API. Null if the request was successful.</param>
    public ApiResponse(bool success, Data? data = null, Error? error = null)
    {
        Success = success;
        Data = data;
        Error = error;
    }

    /// <summary>
    /// Constructor for a response from the API.
    /// </summary>
    /// <param name="success">Whether the request was successful or not.</param>
    public ApiResponse(bool success)
    {
        Success = success;
    }

    /// <summary>
    /// Default constructor
    /// </summary>
    public ApiResponse()
    {
    }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}