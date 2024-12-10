using Microsoft.EntityFrameworkCore;
using TRWalks.API.Models.Domain;

namespace TRWalks.API.Data {


    public class TRWalksDbContext : DbContext {

        public TRWalksDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) {

        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            // Seed data for Difficulties
            var difficulties = new List<Difficulty>
            {
        new Difficulty
        {
            Id = Guid.Parse("a1c8db32-d39d-41af-bb82-89c622c8c555"),
            Name = "Easy"
        },
        new Difficulty
        {
            Id = Guid.Parse("b34ef5a1-73e4-4d22-9124-1bde6a25d53b"),
            Name = "Medium"
        },
        new Difficulty
        {
            Id = Guid.Parse("f3e8cf4a-a789-4bc7-9255-c9c8f2468d44"),
            Name = "Hard"
        }
    };

            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            // Seed data for Regions
            var regions = new List<Region>
            {
        new Region
        {
            Id = Guid.Parse("d7c8a1c8-c349-4f27-9f17-a555e3c8c789"),
            Name = "Tomsk Central",
            Code = "TSC",
            RegionImageUrl = "https://example.com/images/tomsk-central.jpg"
        },
        new Region
        {
            Id = Guid.Parse("8c34ba72-4a1b-4a8e-8d23-1b5c81c56b77"),
            Name = "Siberian Forest",
            Code = "SFR",
            RegionImageUrl = "https://example.com/images/siberian-forest.jpg"
        },
        new Region
        {
            Id = Guid.Parse("c1e7ad3b-f2a6-4c2f-9f91-2f5c8b5a6d8c"),
            Name = "Lenin District",
            Code = "LDN",
            RegionImageUrl = null
        },
        new Region
        {
            Id = Guid.Parse("e8f12ab3-a71d-4e2c-9f23-b8c9f3d8e74a"),
            Name = "University Area",
            Code = "UA",
            RegionImageUrl = "https://example.com/images/university-area.jpg"
        },
        new Region
        {
            Id = Guid.Parse("3a8f4b2c-d7c1-43a2-9f17-8e5b8f2c1d6a"),
            Name = "Historical Quarters",
            Code = "HQ",
            RegionImageUrl = "https://example.com/images/historical-quarters.jpg"
        }
    };

            modelBuilder.Entity<Region>().HasData(regions);

        }
    }
}
