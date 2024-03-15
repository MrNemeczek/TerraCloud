using Microsoft.AspNetCore.Components;
using Radzen;
using System.Net.Http.Json;
using TerraCloud.Application.DTO.Auth.Request;
using TerraCloud.Application.DTO.Auth.Response;
using TerraCloud.Client.Common;

namespace TerraCloud.Client.Pages.Auth
{
    public class LoginBase : ComponentBase
    {
        protected string defaultUsername = "string";
        protected string defaultPassword = "string";
        protected bool rememberMe = true;

        [Inject]
        protected HttpClient _http { get; set; } = default!;
        [Inject]
        private ApiRequest _apiRequest { get; set; } = default!;

        protected async Task<bool> OnLogin(LoginArgs args, string name)
        {
            Console.WriteLine($"{name} -> Username: {args.Username}, password: {args.Password}, remember me: {args.RememberMe}");

            var loginRequest = new LoginRequest
            {
                Login = args.Username,
                Password = args.Password
            };

            //var test = await _http.PostAsJsonAsync<LoginRequest>("api/Auth/login", loginRequest);

            //Console.WriteLine(await test.Content.ReadAsStringAsync());
            var loginResponse = await _apiRequest.PostAsync<LoginResponse, LoginRequest>("api/Auth/login", loginRequest);
            Console.WriteLine(loginResponse.Token);

            return true;
        }

        protected bool OnRegister(string name)
        {
            Console.WriteLine($"{name} -> Register");

            return true;
        }

        protected bool OnResetPassword(string value, string name)
        {
            Console.WriteLine($"{name} -> ResetPassword for user: {value}");

            return true;
        }
    }
}
