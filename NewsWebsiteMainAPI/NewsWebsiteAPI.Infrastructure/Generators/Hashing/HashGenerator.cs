using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using NewsWebsiteAPI.Infrastructure.Models.Configuration;

namespace NewsWebsiteAPI.Infrastructure.Generators.Hashing
{
    public class HashGenerator : IHashGenerator
    {
        private HashConfiguration Configuration { get; }

        public HashGenerator(HashConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Task<byte[]> GenerateSaltedHash(string inputText)
        {
            var bytes = Encoding.UTF8.GetBytes(inputText);

            var hash = new MD5CryptoServiceProvider().ComputeHash(bytes);

            return Task.FromResult(hash);
        }
    }
}