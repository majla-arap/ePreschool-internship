using ePreschool.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePreschool.Infrastructure.Repositories
{
    public class BusinessUnitRepository : BaseRepository<BusinessUnit, int>, IBusinessUnitRepository
    {
        public BusinessUnitRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
