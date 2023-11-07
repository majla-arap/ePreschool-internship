using AutoMapper;

using ePreschool.Core.Dto;
using ePreschool.Core.Entities;
using ePreschool.Infrastructure.Repositories;
using ePreschool.Infrastructure.UnitOfWork;

namespace ePreschool.Service
{

    public class PreschoolsService : BaseService<Preschool, PreschoolDto>, IPreschoolsService
    {
        IPreschoolsRepository _preschoolsRepository;
        public PreschoolsService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            _currentRepository = _preschoolsRepository = ((UnitOfWork)unitOfWork)._preschoolsRepository;
        }      

        public async Task<IEnumerable<EntityItemDto>> GetSelectListAsync()
        {            
            return _mapper.Map<IEnumerable<EntityItemDto>>(await _preschoolsRepository.GetAllAsync());
        }
    }
}
