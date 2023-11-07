using AutoMapper;

using ePreschool.Core.Dto;
using ePreschool.Core.Entities;
using ePreschool.Core.Entities.Identity;

namespace ePreschool.Service.Mapper
{
    public  class MapperProfiles : Profile
    {

        public MapperProfiles()
        {
            CreateMap<ApplicationUser, ApplicationUserDto>().ReverseMap().ForMember(x=>x.UserName, opt => opt.MapFrom(x=>x.UsernName));
            CreateMap<City, CityDto>();
            CreateMap<CityDto, City>().ForMember(x=>x.Country, x=>x.Ignore());

            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Preschool, PreschoolDto>().ReverseMap();
            CreateMap<BusinessUnit, BusinessUnitDto>().ReverseMap();
            CreateMap<ApplicationUserRole, ApplicationUserRoleDto>().ReverseMap();
            CreateMap<BusinessUnitProgram, BusinessUnitProgramDto>().ReverseMap();
            CreateMap<Child, ChildDto>().ReverseMap();
            CreateMap<ParentChild, ParentChildDto>().ReverseMap();
            CreateMap<Parent, ParentDto>().ReverseMap();
            CreateMap<WorkingProgram, WorkingProgramDto>().ReverseMap();

            CreateMap<Log, LogDto>().ReverseMap();

            CreateMap<Country, EntityItemDto>().
               ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id)).
               ForMember(x => x.Label, opt => opt.MapFrom(x => x.Name));


            CreateMap<City, EntityItemDto>().
               ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id)).
               ForMember(x => x.Label, opt => opt.MapFrom(x => x.Name));

            CreateMap<BusinessUnit, EntityItemDto>().
              ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id)).
              ForMember(x => x.Label, opt => opt.MapFrom(x => x.Name));


            CreateMap<Preschool, EntityItemDto>().
               ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id)).
               ForMember(x => x.Label, opt => opt.MapFrom(x => x.Name));

            CreateMap<WorkingProgram, EntityItemDto>().
              ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id)).
              ForMember(x => x.Label, opt => opt.MapFrom(x => x.Name));

        }
    }
}
