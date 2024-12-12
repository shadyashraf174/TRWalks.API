using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TRWalks.API.Data {
    public class TRWalksAuthDbContext : IdentityDbContext {
        public TRWalksAuthDbContext(DbContextOptions<TRWalksAuthDbContext> options) : base(options) {
        }
    }
}
