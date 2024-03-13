namespace TerraCloud.Infrastructure.Interfaces.Auth
{
    public interface IPasswordOperations
    {
        bool VerifyPassword(string password, string hashedPassword, byte[] salt);
        string GenerateHash(string rawPassword, out byte[] salt);
    }
}
