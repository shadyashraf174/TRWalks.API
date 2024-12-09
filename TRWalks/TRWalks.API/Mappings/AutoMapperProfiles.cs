using AutoMapper;
using TRWalks.API.DTO;
using TRWalks.API.Models.Domain;

namespace TRWalks.API.Mappings {
    public class AutoMapperProfiles: Profile {
        public AutoMapperProfiles()
        {
            CreateMap<Region, RegionDTO>().ReverseMap();
            CreateMap<AddRegionRequestDTO, Region>().ReverseMap();
            CreateMap<UpdateRegionRequestDto, Region>().ReverseMap();
        }
    }
}
