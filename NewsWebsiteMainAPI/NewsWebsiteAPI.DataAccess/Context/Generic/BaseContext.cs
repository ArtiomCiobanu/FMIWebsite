using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NewsWebsiteAPI.DataAccess.Context.Generic
{
    public class BaseContext : DbContext, IBaseContext
    {
        public BaseContext(DbContextOptions options) : base(options)
        {
        }

        public Task SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
    }
}