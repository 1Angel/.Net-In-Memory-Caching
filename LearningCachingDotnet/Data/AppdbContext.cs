using LearningCachingDotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningCachingDotnet.Data
{
    public class AppdbContext: DbContext
    {
        public AppdbContext(DbContextOptions<AppdbContext> option): base(option)
        {
            
        }

        public DbSet<Cars> cars { get; set; }
    }
}
