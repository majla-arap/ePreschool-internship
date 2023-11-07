using Dapper;
using ePreschool.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePreschool.Infrastructure.Repositories
{
    public class WorkingProgramRepository : BaseRepository<WorkingProgram, int>, IWorkingProgramRepository
    {
        public WorkingProgramRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<dynamic>> GetAllWithoutDeleted()
        {
            var query = "SELECT * FROM fn_workingprograms_getallwithoutdeleted();";
            return await DbConnection.QueryAsync(query);
        }
    }
}
