using AutoMapper;
using ePreschool.Core.Dto;
using ePreschool.Core.Entities.Identity;
using ePreschool.Infrastructure.Repositories;
using ePreschool.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePreschool.Service
{
    public class ApplicationUserRoleService : BaseService<ApplicationUserRole, ApplicationUserRoleDto>, IApplicationUserRoleService
    {
        IApplicationUserRoleRepository _applicationUserRoleRepository;
        public ApplicationUserRoleService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            _currentRepository = _applicationUserRoleRepository = ((UnitOfWork)unitOfWork)._applicationUserRoleRepository;
        }
    }
}
