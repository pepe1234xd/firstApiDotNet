using Microsoft.EntityFrameworkCore;
using Walks.Api.Data;
using Walks.Api.Models.Domain;

namespace Walks.Api.Repositories
{
    public class WalkRepositorie : IWalkRepositorie
    {
        private readonly WalksDbContext walksDbContext;

        public WalkRepositorie(WalksDbContext walksDbContext)
        {
            this.walksDbContext = walksDbContext;
        }

        public async Task<Walk> AddAsync(Walk walk)
        {
            //assign new id
            walk.Id = new Guid();

            await walksDbContext.Walks.AddAsync(walk);
            await walksDbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk> DeleteAsync(Guid id)
        {
            var existingWalk = await walksDbContext.Walks.FindAsync(id);

            if(existingWalk == null)
            {
                return null;
            }

            walksDbContext.Walks.Remove(existingWalk);
            walksDbContext.SaveChangesAsync();

            return existingWalk;
        }

        public async Task<IEnumerable<Walk>> GetAllAsync()
        {
            return await walksDbContext.Walks
                .Include(x =>x.Region)
                .Include(x => x.WalkDifficult)
                .ToListAsync();
        }

        public Task<Walk> GetAsync(Guid id)
        {
           return walksDbContext.Walks
                .Include(x => x.Region)
                .Include (x => x.WalkDifficult)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Walk> UpdateAsync(Guid id ,Walk walk)
        {
            var existingWalk = await walksDbContext.Walks.FindAsync(id);
            
            if(existingWalk == null)
            {
                return null;
            }

            existingWalk.Length = walk.Length;
            existingWalk.FullName= walk.FullName;
            existingWalk.WalkDifficultId = walk.Id; 
            existingWalk.Region= walk.Region;

            walksDbContext.SaveChangesAsync();
            return existingWalk;

        }
    }
}
