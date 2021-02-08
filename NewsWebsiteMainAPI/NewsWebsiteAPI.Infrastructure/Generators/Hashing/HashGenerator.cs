using System.Security.Cryptography;
using System.Threading.Tasks;

namespace NewsWebsiteAPI.Infrastructure.Generators.Hashing
{
    public class HashGenerator : IHashGenerator
    {
        public async Task<string> GetHash(string text, string salt)
        {
            HashAlgorithm hashAlgorithm = new MD5CryptoServiceProvider();

            string salted = text + salt;

            await hashAlgorithm.ComputeHashAsync();
        }
    }
}