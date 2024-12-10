using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TRWalks.API.Data;
using TRWalks.API.DTO;
using TRWalks.API.Models.Domain;
using TRWalks.API.Repositories;

namespace TRWalks.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase {
        private readonly TRWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(TRWalksDbContext dbContext, IRegionRepository regionRepository, IMapper mapper ) {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll() {
            // Get data from database (domain models)
            var regionsDomain = await regionRepository.GetAllAsync();

            // Return DTOs to the client
            return Ok(mapper.Map<List<RegionDTO>>(regionsDomain));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id) {

            // Get data from database (domain models)
            var regionDomain = await regionRepository.GetByIdAsync(id);

            if (regionDomain == null) {
                return NotFound();
            }

            // Return DTOs to the client
            return Ok(mapper.Map<RegionDTO>(regionDomain));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDTO addRegionRequestDto) {

            if (ModelState.IsValid) {

                // Convert DTO to domain model
                var regionDomainModel = mapper.Map<Region>(addRegionRequestDto);

                // Add to database
                regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);

                // Convert domain model to DTO
                var regionDto = mapper.Map<RegionDTO>(regionDomainModel);

                // Return a 201 response with location
                return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
            }
            return BadRequest(ModelState);
        }


        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto) {

            if (ModelState.IsValid) {
                //Map DTO to domain model
                var regionDomainModel = mapper.Map<Region>(updateRegionRequestDto);

                // Check if region exists
                regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);
                if (regionDomainModel == null) {
                    return NotFound();
                }

                return Ok(mapper.Map<RegionDTO>(regionDomainModel));
            }
            return BadRequest(ModelState);
        }


        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id) {
            var regionDomainModel = await regionRepository.DeleteAsync(id);
            if (regionDomainModel == null) {
                return NotFound();
            }
           
            return Ok(mapper.Map<RegionDTO>(regionDomainModel));
        }
    }
}