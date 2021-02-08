using System.Threading.Tasks;

namespace NewsWebsiteAPI.Infrastructure.Generators.Hashing
{
    public interface IHashGenerator
    {
        public Task<string> GetHash(string text, string salt);
    }
}