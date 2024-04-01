namespace TerraCloud.Application.DTOs.Auth.Requests
{
    public class RegisterRequest
    {
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string ConfirmPassword { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
