using Walks.Api.Models.Domain;

namespace Walks.Api.Repositories
{
    public interface IWalkDificultyRepositorie
    {
        Task<IEnumerable<WalkDifficult>> GetAllAsync();

        Task<WalkDifficult> GetAsync(Guid id);

        Task<WalkDifficult> AddAsync(WalkDifficult walkDifficult);

        Task<WalkDifficult> UpdateAsync(Guid id ,WalkDifficult walkDifficult);

        Task<WalkDifficult> DeleteAsync(Guid id);
    }
}
