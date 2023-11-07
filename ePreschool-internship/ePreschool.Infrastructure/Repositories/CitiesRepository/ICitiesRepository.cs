using ePreschool.Core.Dto;
using ePreschool.Core.Entities;

namespace ePreschool.Infrastructure.Repositories
{
    public interface ICitiesRepository : IBaseRepository<City, int>
    {
        Task<IEnumerable<dynamic>> GetByParametersAsync(string pName, int pCountryId);
    }
}
