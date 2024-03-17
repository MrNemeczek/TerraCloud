using System.Text;
using System.Text.Json;
using TerraCloud.Application.DTO.Error;

namespace TerraCloud.Client.Common
{
    public class ApiRequest : IApiRequest
    {
        private readonly JsonSerializerOptions _options;
        private readonly HttpClient _http;

        public ApiRequest(HttpClient http)
        {
            _options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };
            _http = http;
        }

        public async Task<TResult> PostAsync<TResult, TBody>(string endpoint, TBody body)
        {
            try
            {
                string requestBody = JsonSerializer.Serialize(body);
                var httpContent = new StringContent(requestBody, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _http.PostAsync(endpoint, httpContent);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                TResult result = JsonSerializer.Deserialize<TResult>(responseBody, _options);

                return result;
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());

                throw;
            }
        }
        public async Task<ErrorResponse?> OnlyPostAsync<TBody>(string endpoint, TBody body)
        {
            try
            {
                string requestBody = JsonSerializer.Serialize(body);
                var httpContent = new StringContent(requestBody, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _http.PostAsync(endpoint, httpContent);
                if (!response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var errorResponse = JsonSerializer.Deserialize<ErrorResponse>(responseBody, _options);

                    return errorResponse;
                }

                return null;
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());

                throw;
            }
        }
        public async Task<TResult> GetAsync<TResult>()
        {
            throw new NotImplementedException();
        }
        public async Task<TResult> PutAsync<TResult>()
        {
            throw new NotImplementedException();
        }
    }
}
