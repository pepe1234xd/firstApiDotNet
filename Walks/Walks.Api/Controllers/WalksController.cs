using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Walks.Api.Models.DTO;
using Walks.Api.Repositories;

namespace Walks.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalksController : Controller
    {
        private readonly IWalkRepositorie walkRepositorie;
        private readonly IMapper mapper;

        public WalksController(IWalkRepositorie walkRepositorie, IMapper mapper)
        {
            this.walkRepositorie = walkRepositorie;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWalks()
        {
            var walksDomain =  await walkRepositorie.GetAllAsync();

            var walksDTO = mapper.Map<List<Models.DTO.Walk>>(walksDomain);

            return Ok(walksDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetWalkAsync(Guid id)
        {
            //get walk domain objetc from db
            var walksDomain = walkRepositorie.GetAsync(id);

            //convert  domain objetc to DTO
            var walksDTO = mapper.Map<Models.DTO.Walk>(walksDomain);

            return Ok(walksDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddWalkAsync([FromBody] AddWalkRequest addWalkRequest)
        {
            //convert dto to domain object
            var walkDomain = new Models.Domain.Walk
            {
                Length= addWalkRequest.Length,
                FullName=addWalkRequest.FullName,
                RegionID=addWalkRequest.RegionID,
                WalkDifficultId=addWalkRequest.WalkDifficultId
            };
            //pass domain to repository
            walkDomain = await walkRepositorie.AddAsync(walkDomain);
            //convert the domain object back to dto
            var walkDTO = new Models.DTO.Walk
            {
                Length = walkDomain.Length,
                FullName = walkDomain.FullName,
                RegionID = walkDomain.RegionID,
                Id = walkDomain.Id,
                WalkDifficultId = walkDomain.WalkDifficultId
            };
            //send dto back to client
            return CreatedAtAction(nameof(GetWalkAsync), new { id = walkDTO.Id}, walkDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateWalkAsync([FromRoute] Guid id, [FromBody] Models.DTO.UpdateWalkRequest updateWalkRequest)
        {
            var walkDomain = new Models.Domain.Walk
            {
                Length = updateWalkRequest.Length,
                FullName = updateWalkRequest.FullName,
                RegionID=updateWalkRequest.RegionID,
                WalkDifficultId=updateWalkRequest.WalkDifficultId
            };

            walkDomain = await walkRepositorie.UpdateAsync(id,walkDomain);

            if(walkDomain == null)
            {
                return NotFound();
            }

            var ewalkDTO = new Models.DTO.Walk
            {
                Id= walkDomain.Id,
                Length = walkDomain.Length,
                FullName = walkDomain.FullName,
                RegionID = walkDomain.RegionID,
                WalkDifficultId=walkDomain.WalkDifficultId
            };

            return Ok(ewalkDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteWalkAsync(Guid id)
        {
            var walkDomain = await walkRepositorie.DeleteAsync(id);
            if(walkDomain == null) { return NotFound(); }

            var walkDTO =mapper.Map<Models.DTO.Walk>(walkDomain);
            
            return Ok(walkDTO);
        }
    }
}
