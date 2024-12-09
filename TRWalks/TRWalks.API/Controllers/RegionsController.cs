using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TRWalks.API.Models.Domain;

namespace TRWalks.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase {

        [HttpGet]
        public IActionResult GetAll() {
            var regions = new List<Region> {
                new Region {
                    Id = Guid.NewGuid(),
                    Name = "Leninsky District",
                    Code = "LEN",
                    RegionImageUrl = "https://example.com/leninsky.jpg"
                },
                new Region {
                    Id = Guid.NewGuid(),
                    Name = "Sovetsky District",
                    Code = "SOV",
                    RegionImageUrl = "https://example.com/sovetsky.jpg"
                },
                new Region {
                    Id = Guid.NewGuid(),
                    Name = "Kirovsky District",
                    Code = "KIR",
                    RegionImageUrl = "https://example.com/kirovsky.jpg"
                },
                new Region {
                    Id = Guid.NewGuid(),
                    Name = "Oktyabrsky District",
                    Code = "OKT",
                    RegionImageUrl = "https://example.com/oktyabrsky.jpg"
                }
            };
            return Ok(regions);
        }
    }
}
