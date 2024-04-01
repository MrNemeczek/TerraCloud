using Blazored.LocalStorage;
using System.Text;
using System.Text.Json;
using System.Net.Http.Headers;

using TerraCloud.Application.DTOs.Error;

namespace TerraCloud.Client.Common
{
    public class ApiRequest : IApiRequest
    {
        private readonly JsonSerializerOptions _options;
        private readonly HttpClient _http;
        private readonly ILocalStorageService _localStorageService;

        public ApiRequest(HttpClient http, ILocalStorageService localStorageService)
        {
            _options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            };

            _http = http;
            _localStorageService = localStorageService;            
        }

        public async Task<TResult> PostAsync<TResult, TBody>(string endpoint, TBody body)
        {
            try
            {
                await SetAuthorization();

                string requestBody = JsonSerializer.Serialize(body);
                var httpContent = new StringContent(requestBody, Encoding.UTF8, "application/json");
                
                HttpResponseMessage response = await _http.PostAsync(endpoint, httpContent);
                response.EnsureSuccessStatusCode();

                var result = await DeserializeResponse<TResult>(response);

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
                await SetAuthorization();

                string requestBody = JsonSerializer.Serialize(body);
                var httpContent = new StringContent(requestBody, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _http.PostAsync(endpoint, httpContent);
                if (!response.IsSuccessStatusCode)
                {
                    var errorResponse = await DeserializeResponse<ErrorResponse>(response);

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
        public async Task<TResult> GetAsync<TResult>(string endpoint)
        {
            await SetAuthorization();

            HttpResponseMessage response = await _http.GetAsync(endpoint);
            response.EnsureSuccessStatusCode();

            var result = await DeserializeResponse<TResult>(response);

            return result;
        }
        public async Task<TResult> PutAsync<TResult>(string endpoint)
        {
            await SetAuthorization();

            throw new NotImplementedException();
        }

        private async Task<TResult> DeserializeResponse<TResult>(HttpResponseMessage response)
        {
            string responseBody = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<TResult>(responseBody, _options);

            return result;
        }

        private async Task SetAuthorization()
        {
            string tokenJWT = await _localStorageService.GetItemAsStringAsync("jwt");
            tokenJWT = tokenJWT.Trim('\"');
            _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenJWT);
        }
    }
}
