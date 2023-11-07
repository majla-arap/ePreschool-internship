using AutoMapper;

using ePreschool.Core.Dto;
using ePreschool.Core.Entities;
using ePreschool.Infrastructure.Repositories;
using ePreschool.Infrastructure.UnitOfWork;

namespace ePreschool.Service
{

    public class CountiresService : BaseService<Country, CountryDto>, ICountiresService
    {
        ICountriesRepository _countriesRepository;
        public CountiresService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            _currentRepository = _countriesRepository = ((UnitOfWork)unitOfWork)._countiresRepository;
        }       

        public async Task<IEnumerable<EntityItemDto>> GetSelectListAsync()
        {            
            return _mapper.Map<IEnumerable<EntityItemDto>>(await _countriesRepository.GetAllAsync());
        }
    }
}
