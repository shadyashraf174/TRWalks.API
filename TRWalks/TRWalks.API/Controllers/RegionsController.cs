﻿using Microsoft.AspNetCore.Http;
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

        public RegionsController(TRWalksDbContext dbContext, IRegionRepository regionRepository ) {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {
            // Get data from database (domain models)
            var regionsDomain = await regionRepository.GetAllAsync();

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
        public async Task<IActionResult> GetById([FromRoute] Guid id) {

            // Get data from database (domain models)
            var regionDomain = await regionRepository.GetByIdAsync(id);

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
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDTO addRegionRequest) {
            // Convert DTO to domain model
            var regionDomainModel = new Region {
                Code = addRegionRequest.Code,
                Name = addRegionRequest.Name,
                RegionImageUrl = addRegionRequest.RegionImageUrl
            };

            // Add to database
            regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);

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
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto) {
            //Map DTO to domain model
            var regionDomainModel = new Region {
                Code = updateRegionRequestDto.Code,
                Name = updateRegionRequestDto.Name,
                RegionImageUrl = updateRegionRequestDto.RegionImageUrl
            };

            // Check if region exists
            regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);
            if (regionDomainModel == null) {
                return NotFound();
            }
            
            // Convert Domain Model to DTO
            var regionDto = new RegionDTO {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };
            return Ok(regionDto);
        }

        // Delete Region
        // DELETE: https://localhost:portnumber/api/regions/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id) {
            var regionDomainModel = await regionRepository.DeleteAsync(id);
            if (regionDomainModel == null) {
                return NotFound();
            }
     
            // return deleted Region back
            // map Domain Model to DTO
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