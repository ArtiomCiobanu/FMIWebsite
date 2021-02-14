using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using NewsWebsiteAPI.Models.Configuration;

namespace NewsWebsiteAPI.Infrastructure.Generators.Hashing
{
    public class HashGenerator : IHashGenerator
    {
        private HashConfiguration Configuration { get; }

        public HashGenerator(HashConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task<string> GenerateSaltedHash(string inputText)
        {
            /*byte[] textBytes = Encoding.UTF8.GetBytes(inputText);
            byte[] saltBytes = Encoding.UTF8.GetBytes(Configuration.Salt);

            var md5 = new HMACMD5(saltBytes);
            var saltedHash = md5.ComputeHash(textBytes);

            var hashedText = Encoding.UTF8.GetString(saltedHash);
            return await Task.FromResult(hashedText);*/
            //
            using HashAlgorithm hashAlgorithm = new MD5CryptoServiceProvider();
            await using var inputStream = new MemoryStream();
            var streamWriter = new StreamWriter(inputStream);

            string saltedText = inputText + Configuration.Salt;

            await streamWriter.WriteAsync(saltedText);

            var hash = await hashAlgorithm.ComputeHashAsync(inputStream);

            return Encoding.UTF8.GetString(hash);
        }
    }
}