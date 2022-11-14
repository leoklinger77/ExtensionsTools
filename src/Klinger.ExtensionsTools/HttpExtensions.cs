using System.Net.Http.Json;
using System.Text.Json;

namespace Klinger.ExtensionsTools
{
    public static class HttpExtensions
    {
        public static async Task<HttpResponseMessage> DeleteAsJsonAsync<T>(this HttpClient httpClient, string requestUri, T value) =>
            await httpClient.SendAsync(new HttpRequestMessage
            {
                Content = JsonContent.Create(value),
                Method = HttpMethod.Delete,
                RequestUri = new Uri(requestUri, UriKind.Relative)
            });
        public static string SerializeObject(this object data) =>
            JsonSerializer.Serialize(data);
        public static T? DeserializeObject<T>(this string data) =>
            JsonSerializer.Deserialize<T>(data, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }
}
