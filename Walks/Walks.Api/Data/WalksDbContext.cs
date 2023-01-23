using Microsoft.EntityFrameworkCore;
using Walks.Api.Models.Domain;

namespace Walks.Api.Data
{
    public class WalksDbContext:DbContext
    {
        public WalksDbContext(DbContextOptions<WalksDbContext> options): base (options) 
        {
            
        }

        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<WalkDifficult> WalkDiffiult { get; set; }

    }
}
