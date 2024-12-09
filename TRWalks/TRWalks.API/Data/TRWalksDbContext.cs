using Microsoft.EntityFrameworkCore;
using TRWalks.API.Models.Domain;

namespace TRWalks.API.Data {


    public class TRWalksDbContext: DbContext {

        public TRWalksDbContext(DbContextOptions dbContextOptions) :base(dbContextOptions) 
        {
            
        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> walks { get; set; }

    }
}
