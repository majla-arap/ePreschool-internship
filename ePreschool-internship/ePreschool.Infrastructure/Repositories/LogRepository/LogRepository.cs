using ePreschool.Core.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePreschool.Infrastructure.Repositories
{
    public class LogRepository : BaseRepository<Log, int>, ILogRepository
    {
        public LogRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
