using ePreschool.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePreschool.Infrastructure.Repositories
{
    public class BusinessUnitProgramRepository : BaseRepository<BusinessUnitProgram, int>, IBusinessUnitProgramRepository
    {
        public BusinessUnitProgramRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
