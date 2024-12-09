using Microsoft.EntityFrameworkCore;
using TRWalks.API.Data;
using TRWalks.API.Models.Domain;

namespace TRWalks.API.Repositories {
    public class SQLRegionRepository : IRegionRepository {
        private readonly TRWalksDbContext dbContext;

        public SQLRegionRepository(TRWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Region>> GetAllAsync() {
           return await dbContext.Regions.ToListAsync();
           
        }
    }
}
