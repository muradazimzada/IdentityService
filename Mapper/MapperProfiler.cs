using AutoMapper;
using IdentityService.Domain.Entities;
using IdentityService.Dtos.RequestDtos.Company;

namespace IdentityService.Mapper
{
    public partial class MapperProfiler : Profile
    {
        public MapperProfiler()
        {
            CreateMap<CompanyDto, Company>().ReverseMap();
            CreateMap<CompanyCreateDto, Company>().ReverseMap();

        }
    }
}
