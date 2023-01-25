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
    }
}
