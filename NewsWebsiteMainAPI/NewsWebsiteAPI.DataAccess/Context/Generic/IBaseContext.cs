using System.Threading.Tasks;

namespace NewsWebsiteAPI.DataAccess.Context.Generic
{
    public interface IBaseContext
    {
        public Task SaveChangesAsync();
    }
}