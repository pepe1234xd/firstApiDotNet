using AutoMapper;
using Walks.Api.Models.Domain;

namespace Walks.Api.Profiles
{
    public class WalksProfile : Profile
    {
        public WalksProfile()
        {
            CreateMap<Models.Domain.Walk, Models.DTO.Walk>()
                .ReverseMap();
            CreateMap<Models.Domain.WalkDifficult, Models.DTO.WalkDificulty>()
                .ReverseMap();
        }
    }
}
