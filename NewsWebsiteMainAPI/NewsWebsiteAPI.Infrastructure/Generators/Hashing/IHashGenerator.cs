namespace NewsWebsiteAPI.Infrastructure.Generators.Hashing
{
    public interface IHashGenerator
    {
        public string GetHash(string text, string salt);
    }
}