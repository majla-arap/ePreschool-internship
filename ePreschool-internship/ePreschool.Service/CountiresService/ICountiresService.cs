
using ePreschool.Core.Dto;

namespace ePreschool.Service
{
    public interface ICountiresService : IBaseService<CountryDto>
    {
        Task<IEnumerable<EntityItemDto>> GetSelectListAsync();

    }
}
