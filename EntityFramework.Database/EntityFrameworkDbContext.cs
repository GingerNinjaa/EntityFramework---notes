using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Database
{
    public class EntityFrameworkDbContext : DbContext
    {
        //przekazanie opcji z startup w webapi to bcontext
        public EntityFrameworkDbContext(DbContextOptions options) : base(options)
        {
                
        }

        public DbSet<Setting> Settings { get; set; }
    }
}
