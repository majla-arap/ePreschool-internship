
using ePreschool.Core.Dto;

namespace ePreschool.Service
{
    public interface ICitiesService : IBaseService<CityDto>
    {
        Task<IEnumerable<CityDto>> GetByParametersAsync(string pName, int pCountryId);
        Task<IEnumerable<EntityItemDto>> GetSelectListAsync();

    }
}
