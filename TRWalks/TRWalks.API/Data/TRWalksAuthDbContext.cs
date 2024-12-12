using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TRWalks.API.Data {
    public class TRWalksAuthDbContext : IdentityDbContext {
        public TRWalksAuthDbContext(DbContextOptions<TRWalksAuthDbContext> options) : base(options) {
        
        


        }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);

            var readerRoleId = "8ea6f838 - 1baa - 44f2 - 9cc4 - b66d9a9212d8";
            var writerRoleId = "08aa29a2-8ad2-4a46-ba47-41b9b26bca29";

            var roles = new List<IdentityRole> {
            new IdentityRole{

                Id = readerRoleId,
                ConcurrencyStamp = readerRoleId,
                Name = "Reader",
                NormalizedName = "Reader".ToUpper()

            },
            new IdentityRole{

                Id = writerRoleId,
                ConcurrencyStamp = writerRoleId,
                Name = "Writer",
                NormalizedName = "Writer".ToUpper()
            }
            };

            builder.Entity<IdentityRole>().HasData(roles);

        }

    }
}
