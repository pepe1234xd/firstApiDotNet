using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Walks.Api.Models.Domain;
using Walks.Api.Repositories;

namespace Walks.Api.Controllers
{
    [ApiController]
    //[Route("Regions")]
    [Route("[controller]")]
    public class RegionsController : Controller
    {
        private readonly IRegionRepositorie regionRepositorie;
        private readonly IMapper mapper;

        public RegionsController(IRegionRepositorie regionRepositorie, IMapper mapper)
        {
            this.regionRepositorie = regionRepositorie;
            this.mapper = mapper;
        }



        [HttpGet]
        public async Task<IActionResult> GetAllRegions()
        {
            var regions = await regionRepositorie.GetAllAsync();
            //var regionsDTO = new List<Models.DTO.Region>();
            ////return DTO regions
            //regions.ToList().ForEach(region =>
            //{
            //    var regionsDTO = new Models.DTO.Region()
            //    {
            //        Id = region.Id,
            //        Code = region.Code,
            //        Name = region.Name,
            //        Area = region.Area,
            //        Lat = region.Lat,
            //        Long = region.Long,
            //        Population = region.Population
            //    };
            //});

            var regionsDTO = mapper.Map<List<Models.DTO.Region>>(regions);

            return Ok(regionsDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetRegionAsync")]
        public async Task<IActionResult> GetRegionAsync(Guid id)
        {
            var region = await regionRepositorie.GetAsync(id);

            if (region == null)
            {
                return NotFound();
            }

            var regionDTO = mapper.Map<Models.DTO.Region>(region);

            return Ok(regionDTO);
        }

        [HttpPost] 
        public async Task<IActionResult> AddRegionAsync(Models.DTO.AddRegionRequest addRegionRequest)
        {
            //request dto to domain model
            var region = new Models.DTO.Region
            {
                Code= addRegionRequest.Code,
                Area=addRegionRequest.Area,
                Lat=addRegionRequest.Lat,   
                Long=addRegionRequest.Long,
                Name=addRegionRequest.Name,
                Population=addRegionRequest.Population
            };

            //pass details to repository
            region = await regionRepositorie.AddAsync(region);

            //convert back to dto
            var regionDTO = new Models.DTO.Region
            {
                Id=region.Id,
                Code=region.Code,
                Area=region.Area,
                Lat=region.Lat,
                Long=region.Long,
                Name=region.Name,
                Population=region.Population
            };

            return CreatedAtAction(nameof(GetRegionAsync), new { id = regionDTO.Id }, regionDTO);
        }
    }
}
