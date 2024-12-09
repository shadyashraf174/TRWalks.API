using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TRWalks.API.Data;
using TRWalks.API.DTO;
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
            // Get data from database (domain models)
            var regionsDomain = dbContext.Regions.ToList();

            // Convert domain models to DTOs
            var regionsDTO = new List<RegionDTO>();
            foreach (var regionDomain in regionsDomain) {
                regionsDTO.Add(new RegionDTO {
                    Id = regionDomain.Id,
                    Code = regionDomain.Code,
                    Name = regionDomain.Name,
                    RegionImageUrl = regionDomain.RegionImageUrl
                });
            }

            // Return DTOs to the client
            return Ok(regionsDTO);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id) {

            // Get data from database (domain models)
            var regionDomain = dbContext.Regions.Find(id);

            if (regionDomain == null) {
                return NotFound();
            }
            // Convert domain models to DTOs
            var regionDTO = new RegionDTO {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl
            };
            // Return DTOs to the client
            return Ok(regionDTO);
        }

        [HttpPost]
        public IActionResult Create([FromBody] AddRegionRequestDTO addRegionRequest) {
            // Convert DTO to domain model
            var regionDomainModel = new Region {
                Code = addRegionRequest.Code,
                Name = addRegionRequest.Name,
                RegionImageUrl = addRegionRequest.RegionImageUrl
            };

            // Add to database
            dbContext.Regions.Add(regionDomainModel);
            dbContext.SaveChanges();

            // Convert domain model to DTO
            var regionDto = new RegionDTO {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };

            // Return a 201 response with location
            return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
        }

        // Update region
        // PUT: https://localhost:portnumber/api/regions/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        public IActionResult Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto) {
            // Check if region exists
            var regionDomainModel = dbContext.Regions.FirstOrDefault(x => x.Id == id);
            if (regionDomainModel == null) {
                return NotFound();
            }
            // Map DTO to Domain model
            regionDomainModel.Code = updateRegionRequestDto.Code;
            regionDomainModel.Name = updateRegionRequestDto.Name;
            regionDomainModel.RegionImageUrl = updateRegionRequestDto.RegionImageUrl;
            dbContext.SaveChanges();
            // Convert Domain Model to DTO
            var regionDto = new RegionDTO {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };
            return Ok(regionDto);
        }
    }
}