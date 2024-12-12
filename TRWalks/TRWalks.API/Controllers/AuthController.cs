using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TRWalks.API.DTO;
using TRWalks.API.Models.DTO;
using TRWalks.API.Repositories;

namespace TRWalks.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository) {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }


        // POST: /api/Auth/Regidter
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Reggister([FromBody] RegisterRequestDto registerRequestDto) {

            var identityUser = new IdentityUser {

                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Username

            };

            var identityResult = await userManager.CreateAsync(identityUser, registerRequestDto.Password);

            if (identityResult.Succeeded) {

                // Add roles to this user 
                if (registerRequestDto.Roles != null && registerRequestDto.Roles.Any()) {
                    identityResult = await userManager.AddToRolesAsync(identityUser, registerRequestDto.Roles);

                    if (identityResult.Succeeded) {
                        return Ok("User was registered! Please Login.");
                    }
                }
            }
            return BadRequest("somethis went Wrong");
        }


        // POST: /api/Auth/Login
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto) {

            var user = await userManager.FindByNameAsync(loginRequestDto.Username);

            if (user != null) {
                var checkPasswordResult = await userManager.CheckPasswordAsync(user, loginRequestDto.Password);

                if (checkPasswordResult) {

                    // Get Roles for this user
                    var roles = await userManager.GetRolesAsync(user);

                    if (roles != null) {

                        // Create Token
                        var jwtToken = tokenRepository.CreateJWTToken(user, roles.ToList());

                        var response = new LoginResponseDto {

                            JwtToken = jwtToken

                        };

                    return Ok(response);
                    }
                }
            }
            return BadRequest("Username or password incorrect");

        }
    }
}
