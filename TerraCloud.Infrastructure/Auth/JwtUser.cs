namespace TerraCloud.Infrastructure.Auth
{
    public class JwtUser
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
    }
}
