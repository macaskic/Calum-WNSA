using AutoMapper;
using WNSA.Dtos;
using WNSA.Models;
//using WNSA.Profiles;

namespace WNSA.Profiles
{
    public class WNSAProfile : Profile
    {
        public WNSAProfile()
        {
            // Source -> Destination Target
            CreateMap<WNSAModel, WNSAReadDto>();
            CreateMap<WNSACreateDto, WNSAModel>();
            CreateMap<WNSAUpdateDto, WNSAModel>();
            CreateMap<WNSAModel, WNSAUpdateDto>();
        }
    }
}