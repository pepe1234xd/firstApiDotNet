using Walks.Api.Models.Domain;

namespace Walks.Api.Repositories
{
    public interface IRegionRepositorie
    {
        Task<IEnumerable<Region>> GetAllAsync();

        Task<Region> GetAsync(Guid id);

        Task<Region> AddAsync(Region region);
    }
}
