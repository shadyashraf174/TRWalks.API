using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TRWalks.API.DTO;
using TRWalks.API.Models.Domain;
using TRWalks.API.Repositories;

namespace TRWalks.API.Controllers {

    // /api/walks
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        public WalksController(IMapper mapper, IWalkRepository walkRepository) {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }

        // GREATE Walk
        // POST: /api/walks
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto) {

            //Map DTO to Domain Model 
            var walkDomainModel = mapper.Map<Walk>(addWalkRequestDto);

            await walkRepository.CreateAsync(walkDomainModel);

            // Map Domain model to DTO
            return Ok(mapper.Map<WalkDto>(walkDomainModel));

        }


        // GET Walks
        // GET: /api/walks 
        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var walksDomainModel = await walkRepository.GetAllAsync();

            //Map Domain model to DTO
            return Ok(mapper.Map<List<WalkDto>>(walksDomainModel));
        }

        // GET Walk By Id
        // GET: /api/walks/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id) {
            var walkDomainModel = await walkRepository.GetByIdAsync(id);

            if (walkDomainModel == null) {
                return NotFound();
            }
            // Map Domain model to DTO
            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }

        // PUT Walk
        // PUT: GET: /api/walks/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateWalkRequestDto updateWalkRequestDto) {

            //Map DTO to Domain Model
            var walkDomainModel = mapper.Map<Walk>(updateWalkRequestDto);

            walkDomainModel = await walkRepository.UpdateAsync(id, walkDomainModel);

            if (walkDomainModel == null) {
                return NotFound();
            }

            // Map Domain Model To DTO
            return Ok(mapper.Map<WalkDto>(walkDomainModel));

        }


        //DELET Walk By Id
        //DELET: /api/walks/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id) {

            var deleteWalkDomainModel = await walkRepository.DeleteAsync(id);

            if (deleteWalkDomainModel == null) {
                return NotFound();
            }
            // Map Domain model to DTO
            return Ok(mapper.Map<WalkDto>(deleteWalkDomainModel));
        }
    }
}
