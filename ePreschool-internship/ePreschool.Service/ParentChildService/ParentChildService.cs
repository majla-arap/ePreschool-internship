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
    public class ParentChildService : BaseService<ParentChild, ParentChildDto>, IParentChildService
    {
        IParentChildRepository _parentChildRepository;

        public ParentChildService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            _currentRepository = _parentChildRepository = ((UnitOfWork)unitOfWork)._parentChildRepository;
        }

        public async Task AddChildParent(string mail, string cguid)
        {
            await _parentChildRepository.AddChildParent(mail, cguid);
        }
    }
}
