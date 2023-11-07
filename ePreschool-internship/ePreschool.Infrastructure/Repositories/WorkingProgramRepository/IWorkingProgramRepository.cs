﻿using ePreschool.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePreschool.Infrastructure.Repositories
{
    public interface IWorkingProgramRepository : IBaseRepository<WorkingProgram, int>
    {
        Task<IEnumerable<dynamic>> GetAllWithoutDeleted();
    }
}
