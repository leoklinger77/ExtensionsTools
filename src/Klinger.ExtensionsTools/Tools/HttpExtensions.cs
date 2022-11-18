using System.Net.Http.Json;
using System.Text.Json;

namespace Klinger.ExtensionsTools.Tools
{
    public static class HttpExtensions
    {
        /* Description
         * Http Delete as Json
         */
        public static async Task<HttpResponseMessage> DeleteAsJsonAsync<T>(this HttpClient httpClient, string requestUri, T value) =>
            await httpClient.SendAsync(new HttpRequestMessage
            {
                Content = JsonContent.Create(value),
                Method = HttpMethod.Delete,
                RequestUri = new Uri(requestUri, UriKind.Relative)
            });

        /* Description
         * Serializar Objet
         */
        public static string SerializeObject(this object data) =>
            JsonSerializer.Serialize(data);

        /* Description
         * Deserializar string para Object
         */
        public static T DeserializeObject<T>(this string data) =>
            JsonSerializer.Deserialize<T>(data, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }
}
