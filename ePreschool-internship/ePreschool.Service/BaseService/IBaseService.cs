using ePreschool.Infrastructure.Reporsitories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePreschool.Service
{
    public interface IBaseService<TEntityDto> where TEntityDto : class
    {
        Task<TEntityDto> AddAsync(TEntityDto entityDto);
        Task<List<TEntityDto>> GetAllAsync();
        Task<TEntityDto> GetByIdAsync(int id);
        Task RemoveByIdAsync(int id, bool isSoft = true);
        Task Update(TEntityDto entity);

        Task<TEntityDto> UpdateAsync(TEntityDto entityDto) => throw new NotImplementedException();
        Task AddRangeAsync(IEnumerable<TEntityDto> entitiesDto) => throw new NotImplementedException();
        void UpdateRange(IEnumerable<TEntityDto> entitiesDto) => throw new NotImplementedException();

    } 

}
