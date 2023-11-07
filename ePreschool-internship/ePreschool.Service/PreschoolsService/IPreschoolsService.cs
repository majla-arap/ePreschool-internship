
using ePreschool.Core.Dto;

namespace ePreschool.Service
{
    public interface IPreschoolsService : IBaseService<PreschoolDto>
    {
        Task<IEnumerable<EntityItemDto>> GetSelectListAsync();

    }
}
