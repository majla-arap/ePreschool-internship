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
    public class WorkingProgramService : BaseService<WorkingProgram, WorkingProgramDto>, IWorkingProgramService
    {
        IWorkingProgramRepository _programRepository;

        public WorkingProgramService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            _currentRepository = _programRepository = ((UnitOfWork)unitOfWork)._programRepository;
        }

        public async Task<IEnumerable<WorkingProgramDto>> GetAllWithoutDeleted()
        {
            return _mapper.Map<IEnumerable<WorkingProgramDto>>(await _programRepository.GetAllWithoutDeleted());
        }

        public async Task<IEnumerable<EntityItemDto>> GetSelectListAsync()
        {
            return _mapper.Map<IEnumerable<EntityItemDto>>(await _programRepository.GetAllAsync());
        }
    }
}
