using Walks.Api.Models.Domain;

namespace Walks.Api.Repositories
{
    public interface IWalkRepositorie
    {
        Task<IEnumerable<Walk>> GetAllAsync();
        
        Task<Walk> GetAsync(Guid id);

        Task<Walk> AddAsync(Walk walk);

        Task<Walk> UpdateAsync(Guid id,Walk walk);

        Task<Walk> DeleteAsync(Guid id);
    }
}
