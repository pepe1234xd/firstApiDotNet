using Microsoft.EntityFrameworkCore;
using Walks.Api.Data;
using Walks.Api.Models.Domain;

namespace Walks.Api.Repositories
{
    public class RegionRepositorie : IRegionRepositorie
    {
        private readonly WalksDbContext walksDbContext;

        public RegionRepositorie(WalksDbContext walksDbContext)
        {
            this.walksDbContext = walksDbContext;
        }

        public async Task<Region> AddAsync(Region region)
        {
            region.Id = Guid.NewGuid();
            await walksDbContext.AddAsync(region);
            await walksDbContext.SaveChangesAsync();
            return region;
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await walksDbContext.Regions.ToListAsync();
        }

        public async Task<Region> GetAsync(Guid id)
        {
           return await walksDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
