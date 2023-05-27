namespace ImperialSharp.Extensions;

internal static class HttpClientExtensions
{
    internal static async Task<HttpResponseMessage> PatchAsync(this HttpClient client, string requestUri,
        HttpContent content)
    {
        var method = new HttpMethod("PATCH");
        var request = new HttpRequestMessage(method, requestUri)
        {
            Content = content,
        };
        return await client.SendAsync(request);
    }
}