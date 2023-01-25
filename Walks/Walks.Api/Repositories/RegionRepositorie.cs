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

        public IEnumerable<Region> GetAll()
        {
            return walksDbContext.Regions.ToList();
        }
    }
}
