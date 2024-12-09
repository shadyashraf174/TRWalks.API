using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TRWalks.API.Data;
using TRWalks.API.Models.Domain;

namespace TRWalks.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase {
        private readonly TRWalksDbContext dbContext;

        public RegionsController(TRWalksDbContext dbContext) {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAll() {

            var regions = dbContext.Regions.ToList();

            return Ok(regions);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id) {
            var regions = dbContext.Regions.Find(id);

            if (regions == null) {
                return NotFound();
            }
            return Ok(regions);
        }
    }
}