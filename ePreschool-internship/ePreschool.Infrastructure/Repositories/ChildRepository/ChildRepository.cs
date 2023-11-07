using Dapper;
using ePreschool.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePreschool.Infrastructure.Repositories
{
    public class ChildRepository : BaseRepository<Child, int>, IChildRepository
    {
        public ChildRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
