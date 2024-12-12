using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using TRWalks.API.Data;
using TRWalks.API.Models.Domain;

namespace TRWalks.API.Repositories {
    public class SQLWalkRepository : IWalkRepository {
        private readonly TRWalksDbContext dbContext;

        public SQLWalkRepository(TRWalksDbContext dbContext) {
            this.dbContext = dbContext;
        }

        public async Task<Walk> CreateAsync(Walk walk) {

            await dbContext.walks.AddAsync(walk);
            await dbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk?> DeleteAsync(Guid id) {
            var existinhWalk = await dbContext.walks.FirstOrDefaultAsync(x => x.Id == id);

            if (existinhWalk == null) {
                return null;
            }
            dbContext.walks.Remove(existinhWalk);
            await dbContext.SaveChangesAsync();
            return existinhWalk;
        }

            public async Task<List<Walk>> GetAllAsync(
                string? filterOn = null, 
                string? filterQuery = null,
                string? sortBy = null,
                bool isAscending = true
                ) {
            var walks = dbContext.walks.Include("Difficulty").Include("Region").AsQueryable();

            //Filtering
            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false) {
                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase)) {
                    walks = walks.Where(x => x.Name.Contains(filterQuery));
                } 
            }

            //Sorting 
            if (string.IsNullOrWhiteSpace(sortBy) == false ) {
                if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase)) {
                    walks = isAscending ? walks.OrderBy(x => x.Name) : walks.OrderByDescending(x => x.Name);
                
                } else if (sortBy.Equals("Length", StringComparison.OrdinalIgnoreCase)) { 
                    walks = isAscending ? walks.OrderBy(x => x.LengthInKm) : walks.OrderByDescending(x => x.LengthInKm);
                }
            } 

            return await walks.ToListAsync();

            //return await dbContext.walks.Include("Difficulty").Include("Region").ToListAsync();

        }

        public async Task<Walk?> GetByIdAsync(Guid id) {
            return await dbContext.walks
                 .Include("Difficulty")
                 .Include("Region")
                 .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Walk?> UpdateAsync(Guid id, Walk walk) {

            var existinhWalk = await dbContext.walks.FirstOrDefaultAsync(x => x.Id == id);

            if (existinhWalk == null) {
                return null;
            }

            existinhWalk.Name = walk.Name;
            existinhWalk.Description = walk.Description;
            existinhWalk.LengthInKm = walk.LengthInKm;
            existinhWalk.WalkImageUrl = walk.WalkImageUrl;
            existinhWalk.DifficultyId = walk.DifficultyId;
            existinhWalk.RegionId = walk.RegionId;

            await dbContext.SaveChangesAsync();
            return existinhWalk;
        }
    }
}
