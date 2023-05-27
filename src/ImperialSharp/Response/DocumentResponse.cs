using Newtonsoft.Json;
using ImperialSharp.Types;

namespace ImperialSharp.Response;

/// <summary>
///  Represents a response from the API.
/// </summary>
public class DocumentResponse
{
    /// <summary>
    /// Whether the request was successful or not.
    /// </summary>
    [JsonProperty("success")]
    public bool Success { get; set; }

    /// <summary>
    ///  The data returned from the API.
    ///  Null if the request was not successful.
    /// </summary>
    [JsonProperty("data")]
    public Data? Data { get; set; }

    /// <summary>
    ///  The error returned from the API.
    ///  Null if the request was successful.
    /// </summary>

    [JsonProperty("error")]
    public Error? Error { get; set; }
}