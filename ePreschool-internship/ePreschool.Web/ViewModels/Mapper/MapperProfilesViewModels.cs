using AutoMapper;
using ePreschool.Core.Dto;

namespace ePreschool.Web.ViewModels.Mapper
{
    public class MapperProfilesViewModels : Profile
    {
        public MapperProfilesViewModels()
        {

            CreateMap<NewUserViewModel, ApplicationUserDto>();

        }
    }
}
