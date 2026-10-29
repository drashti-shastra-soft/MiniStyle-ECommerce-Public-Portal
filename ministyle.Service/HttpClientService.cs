using ministyle.Infrastructure;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace ministyle.Service
{
    public class HttpClientService : IHttpClientService
    {

        #region Declaration
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpClientService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        #endregion

        #region Public Method
        private HttpClient CreateClient(string token = null)
        {
            var client = _httpClientFactory.CreateClient();

            if (!string.IsNullOrWhiteSpace(token))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            return client;
        }

        public async Task<TR> GetAsync<TR>(string url, string token = null)
        {
            var client = CreateClient(token);
            var response = await client.GetAsync(url).ConfigureAwait(false);
            var contentString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<TR>(contentString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }

            throw response.StatusCode switch
            {
                HttpStatusCode.Unauthorized => new UnauthorizedAccessException("Authorization has been denied for this request."),
                HttpStatusCode.BadRequest => new Exception(JsonSerializer.Deserialize<string>(contentString) ?? "Bad Request!"),
                _ => new Exception("Internal server error!")
            };
        }

        public async Task<TR> PostAsync<T, TR>(string url, T obj, string token = null)
        {
            var client = CreateClient(token);
            using var content = new StringContent(JsonSerializer.Serialize(obj), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, content).ConfigureAwait(false);
            var contentString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return response.StatusCode switch
            {
                HttpStatusCode.OK => JsonSerializer.Deserialize<TR>(contentString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }),
                HttpStatusCode.Unauthorized => throw new UnauthorizedAccessException("Authorization has been denied for this request."),
                HttpStatusCode.BadRequest => throw new Exception(JsonSerializer.Deserialize<string>(contentString) ?? "Bad Request!"),
                _ => throw new Exception("Internal server error!")
            };
        }

        public async Task<T> PostAsync<T>(string url, T obj, string token = null)
        {
            var client = CreateClient(token);
            using var content = new StringContent(JsonSerializer.Serialize(obj), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, content).ConfigureAwait(false);
            var contentString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return response.StatusCode switch
            {
                HttpStatusCode.OK => JsonSerializer.Deserialize<T>(contentString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }),
                HttpStatusCode.Unauthorized => throw new UnauthorizedAccessException("Authorization has been denied for this request."),
                HttpStatusCode.BadRequest => throw new Exception(JsonSerializer.Deserialize<string>(contentString) ?? "Bad Request!"),
                _ => throw new Exception("Internal server error!")
            };
        }

        public async Task PutAsync<T>(string url, T obj, string token = null)
        {
            var client = CreateClient(token);
            using var content = new StringContent(JsonSerializer.Serialize(obj), Encoding.UTF8, "application/json");

            var response = await client.PutAsync(url, content).ConfigureAwait(false);
            var contentString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (response.IsSuccessStatusCode) return;

            throw response.StatusCode switch
            {
                HttpStatusCode.Unauthorized => new UnauthorizedAccessException("Authorization has been denied for this request."),
                HttpStatusCode.BadRequest => new Exception(JsonSerializer.Deserialize<string>(contentString) ?? "Bad Request!"),
                _ => new Exception("Internal server error!")
            };
        }

        public async Task DeleteAsync(string url, string token = null)
        {
            var client = CreateClient(token);
            var response = await client.DeleteAsync(url).ConfigureAwait(false);
            var contentString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (response.IsSuccessStatusCode) return;

            throw response.StatusCode switch
            {
                HttpStatusCode.Unauthorized => new UnauthorizedAccessException("Authorization has been denied for this request."),
                HttpStatusCode.BadRequest => new Exception(JsonSerializer.Deserialize<string>(contentString) ?? "Bad Request!"),
                _ => new Exception("Internal server error!")
            };
        }

        public async Task PatchAsync(string url, string token = null)
        {
            var client = CreateClient(token);
            var request = new HttpRequestMessage(HttpMethod.Patch, url);

            var response = await client.SendAsync(request).ConfigureAwait(false);
            var contentString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (response.IsSuccessStatusCode) return;

            throw response.StatusCode switch
            {
                HttpStatusCode.Unauthorized => new UnauthorizedAccessException("Authorization has been denied for this request."),
                HttpStatusCode.BadRequest => new Exception(JsonSerializer.Deserialize<string>(contentString) ?? "Bad Request!"),
                _ => new Exception("Internal server error!")
            };
        }

        #endregion
    }
}
