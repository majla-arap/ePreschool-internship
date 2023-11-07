using AutoMapper;

using ePreschool.Core.Dto;
using ePreschool.Core.Entities;
using ePreschool.Infrastructure.Repositories;
using ePreschool.Infrastructure.UnitOfWork;

namespace ePreschool.Service
{

    public class CitiesService : BaseService<City, CityDto>, ICitiesService
    {
        ICitiesRepository _cityRepository;
        public CitiesService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            _currentRepository = _cityRepository = ((UnitOfWork)unitOfWork)._citiesRepository;
        }

        public async Task<IEnumerable<CityDto>> GetByParametersAsync(string pName, int pCountryId)
        {
            return _mapper.Map<IEnumerable<CityDto>>(await _cityRepository.GetByParametersAsync(pName, pCountryId));
        }

        public async Task<IEnumerable<EntityItemDto>> GetSelectListAsync()
        {            
            return _mapper.Map<IEnumerable<EntityItemDto>>(await _cityRepository.GetAllAsync());
        }
    }
}
