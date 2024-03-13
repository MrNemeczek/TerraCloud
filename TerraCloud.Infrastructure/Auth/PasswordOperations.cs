using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TerraCloud.Application.Interfaces.Infrastructure.Auth;

namespace TerraCloud.Infrastructure.Auth
{
    internal class PasswordOperations : IPasswordOperations
    {
        private const int keySize = 32;
        private const int iterations = 350000;

        private HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

        public string GenerateHash(string rawPassword, out byte[] salt)
        {
            salt = RandomNumberGenerator.GetBytes(keySize);

            var hash = Rfc2898DeriveBytes.Pbkdf2(
            Encoding.UTF8.GetBytes(rawPassword),
            salt,
            iterations,
            hashAlgorithm,
            keySize);

            return Convert.ToHexString(hash);
        }

        public bool VerifyPassword(string password, string hashedPassword, byte[] salt)
        {
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, hashAlgorithm, keySize);
            return CryptographicOperations.FixedTimeEquals(hashToCompare, Convert.FromHexString(hashedPassword));
        }
    }
}
