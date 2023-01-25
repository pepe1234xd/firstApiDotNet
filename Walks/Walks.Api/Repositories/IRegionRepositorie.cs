using Walks.Api.Models.Domain;

namespace Walks.Api.Repositories
{
    public interface IRegionRepositorie
    {
        Task<IEnumerable<Region>> GetAll();

    }
}
