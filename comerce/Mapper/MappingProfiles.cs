using AutoMapper;
using comerce.Core.Dtos.Request;
using comerce.Core.Dtos.Response;
using comerce.Core.Entities;

namespace comerce.Api.Mapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Concert, ConcertRequestDto>().ReverseMap();
            CreateMap<Concert, ConcertResponseDto>().ReverseMap();

        }
    }
}
