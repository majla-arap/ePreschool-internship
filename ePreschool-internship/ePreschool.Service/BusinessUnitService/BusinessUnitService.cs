using AutoMapper;
using ePreschool.Core.Dto;
using ePreschool.Core.Entities;
using ePreschool.Infrastructure.Repositories;
using ePreschool.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePreschool.Service
{
    public class BusinessUnitService : BaseService<BusinessUnit, BusinessUnitDto>, IBusinessUnitService
    {
        IBusinessUnitRepository _businessUnitRepository;
        public BusinessUnitService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            _currentRepository = _businessUnitRepository = ((UnitOfWork)unitOfWork)._businessUnitRepository;
        }

        public async Task<IEnumerable<EntityItemDto>> GetSelectListAsync()
        {
            return _mapper.Map<IEnumerable<EntityItemDto>>(await _businessUnitRepository.GetAllAsync());
        }
    }
}
