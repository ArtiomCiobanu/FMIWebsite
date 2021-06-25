using System.Threading.Tasks;

namespace NewsWebsiteAPI.Infrastructure.Generators.Hashing
{
    public interface IHashGenerator
    {
        public Task<byte[]> GenerateSaltedHash(string inputText);
    }
}