using Api.DTO;
using Api.Entity;
using AutoMapper;

namespace Api.AutoMapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<BrandsCarsEntity, BrandsCarsDTO>().ReverseMap();
        }
    }
}
