using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Walks.Api.Repositories;

namespace Walks.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalkDificultiesController : Controller
    {
        private readonly IWalkDificultyRepositorie walkDificultyRepositorie;
        private readonly Mapper mapper;

        public WalkDificultiesController(IWalkDificultyRepositorie walkDificultyRepositorie, Mapper mapper)
        {
            this.walkDificultyRepositorie = walkDificultyRepositorie;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWalkDificulties()
        {
            var walkDifficutly = await walkDificultyRepositorie.GetAllAsync();
            var walkDificultyDTO = mapper.Map<Models.DTO.WalkDificulty>(walkDifficutly);
            return Ok(walkDificultyDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetWalkDificulties")]
        public async Task<IActionResult> GetWalkDificulties(Guid id)
        {
            var walkDifficutly = await walkDificultyRepositorie.GetAsync(id);

            if(walkDifficutly == null)
            {
                return NotFound();
            }
            var walkDificultyDTO = mapper.Map<Models.DTO.WalkDificulty>(walkDifficutly);

            return Ok(walkDificultyDTO);
        }


        [HttpPost]
        public async Task<IActionResult> AddWalkDificulties(Models.DTO.AddWalkDificultyRequest addWalkDificultyRequest)
        {
            var walkDificultyDomain = new Models.Domain.WalkDifficult
            {
                Code = addWalkDificultyRequest.Code
            };

            walkDificultyDomain = await walkDificultyRepositorie.AddAsync(walkDificultyDomain);

            var walkDificultyDTO = mapper.Map<Models.DTO.WalkDificulty>(walkDificultyDomain);

            return CreatedAtAction(nameof(GetWalkDificulties), new { id = walkDificultyDTO.Id}, walkDificultyDTO);
        
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateWalkDificulties(Guid id ,Models.DTO.UpdateWalkDificultyRequest updateWalkDificultyRequest)
        {
            var walkDificultyDomain = new Models.Domain.WalkDifficult
            {
                Code = updateWalkDificultyRequest.Code
            };

            walkDificultyDomain = await walkDificultyRepositorie.UpdateAsync(id, walkDificultyDomain);
            
            if(walkDificultyDomain == null)
            {
                return NotFound();
            }

            var walkDificultyDTO = mapper.Map<Models.DTO.WalkDificulty>(walkDificultyDomain);
            
            return Ok(walkDificultyDTO);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteWalkDificulties(Guid id)
        {
            var walkDificulty = await walkDificultyRepositorie.DeleteAsync(id);
            
            if(walkDificulty == null)
            {
                return NotFound();
            }

            var walkDificultyDTO = mapper.Map<Models.DTO.WalkDificulty>(walkDificulty);

            return Ok(walkDificultyDTO);
        }
    }
}
