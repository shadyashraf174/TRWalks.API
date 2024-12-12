using Microsoft.AspNetCore.Identity;

namespace TRWalks.API.Repositories {
    public interface ITokenRepository {

       string CreateJWTToken(IdentityUser user, List<string> roles);

    }
}
