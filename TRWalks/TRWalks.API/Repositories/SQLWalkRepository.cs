using Microsoft.EntityFrameworkCore;
using TRWalks.API.Data;
using TRWalks.API.Models.Domain;

namespace TRWalks.API.Repositories {
    public class SQLWalkRepository : IWalkRepository {
        private readonly TRWalksDbContext dbContext;

        public SQLWalkRepository(TRWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Walk> CreateAsync(Walk walk) {

            await dbContext.walks.AddAsync(walk);
            await dbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<List<Walk>> GetAllAsync() {
            return await dbContext.walks.Include("Difficulty").Include("Region").ToListAsync();
        }
    }
}
