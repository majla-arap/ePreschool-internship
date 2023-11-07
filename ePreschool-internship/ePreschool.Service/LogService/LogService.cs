using AutoMapper;

using ePreschool.Core.Dto;
using ePreschool.Core.Entities;
using ePreschool.Infrastructure.UnitOfWork;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ePreschool.Infrastructure.Reporsitories;
using ePreschool.Infrastructure.Repositories;

namespace ePreschool.Service
{

    public class LogService : BaseService<Log, LogDto>, ILogService
    {
        ILogRepository _logRepository; 
        public LogService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            _currentRepository = _logRepository = ((UnitOfWork)unitOfWork)._logRepository;
        }
    }  
}
