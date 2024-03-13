using Microsoft.AspNetCore.Components;
using Radzen;

namespace TerraCloud.Client.Pages.Auth
{
    public class RegistryBase : ComponentBase
    {
        protected string userName = "admin";
        protected string password = "admin";
        protected string email = "admin@wp.pl";

        protected bool popup;

        protected bool OnLogin(LoginArgs args, string name)
        {
            Console.WriteLine($"{name} -> Username: {args.Username}, password: {args.Password}, remember me: {args.RememberMe}");

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
