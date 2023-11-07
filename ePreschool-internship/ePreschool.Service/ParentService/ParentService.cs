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
    public class ParentService : BaseService<Parent, ParentDto>, IParentService
    {
        IParentRepository _parentRepository;

        public ParentService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            _currentRepository = _parentRepository = ((UnitOfWork)unitOfWork)._parentRepository;
        }

        public async Task<IEnumerable<ParentDto>> GetParentByEmail(string mail)
        {
            return _mapper.Map<IEnumerable<ParentDto>>(await _parentRepository.GetParentByEmail(mail));
        }
    }
}
