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
    }
}
