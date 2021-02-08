using System.Security.Cryptography;

namespace NewsWebsiteAPI.Infrastructure.Generators.Hashing
{
    public class HashGenerator : IHashGenerator
    {
        public async string GetHash(string text, string salt)
        {
            HashAlgorithm hashAlgorithm = new MD5CryptoServiceProvider();

            string salted = text + salt;

            await hashAlgorithm.ComputeHashAsync();
        }
    }
}