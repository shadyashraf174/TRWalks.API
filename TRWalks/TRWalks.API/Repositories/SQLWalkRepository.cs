﻿using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Walk>> GetAllAsync() {
            return await dbContext.walks.Include("Difficulty").Include("Region").ToListAsync();
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
