using Microsoft.EntityFrameworkCore;
using Walks.Api.Data;
using Walks.Api.Models.Domain;

namespace Walks.Api.Repositories
{
    public class WalkDificultyRepositorie : IWalkDificultyRepositorie
    {
        private readonly WalksDbContext walksDbContext;

        public WalkDificultyRepositorie(WalksDbContext walksDbContext)
        {
            this.walksDbContext = walksDbContext;
        }

        public async Task<WalkDifficult> AddAsync(WalkDifficult walkDifficult)
        {
            walkDifficult.Id = new Guid();
            await walksDbContext.WalkDiffiult.AddAsync(walkDifficult);
            await walksDbContext.SaveChangesAsync();
            return walkDifficult;
        }

        public async Task<WalkDifficult> DeleteAsync(Guid id)
        {
            var existingWalkDificulty = await walksDbContext.WalkDiffiult.FindAsync(id);
            
            if(existingWalkDificulty == null)
            {
                return null; 
            }

            walksDbContext.WalkDiffiult.Remove(existingWalkDificulty);
            await walksDbContext.SaveChangesAsync();
            return existingWalkDificulty;
        }

        public async Task<IEnumerable<WalkDifficult>> GetAllAsync()
        {
           return await walksDbContext.WalkDiffiult.ToListAsync();   
        }

        public async Task<WalkDifficult> GetAsync(Guid id)
        {
            return await walksDbContext.WalkDiffiult.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<WalkDifficult> UpdateAsync(Guid id, WalkDifficult walkDifficult)
        {
           var existingWalkDificulty =  await walksDbContext.WalkDiffiult.FindAsync(id);

            if (existingWalkDificulty == null)
            {
                return null;
            }

            existingWalkDificulty.Code = walkDifficult.Code;
            await walksDbContext.SaveChangesAsync();
            return existingWalkDificulty;
        }
    }
}
