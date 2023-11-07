using Dapper;
using ePreschool.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePreschool.Infrastructure.Repositories
{
    public class ParentChildRepository : BaseRepository<ParentChild, int>, IParentChildRepository
    {
        public ParentChildRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<dynamic>> AddChildParent(string mail, string cguid)
        {
            var query = "SELECT FROM public.fn_parentchildren_addrelation(@mail,@cguid);";

            return await DbConnection.QueryAsync(query, new DynamicParameters(new { mail = mail, cguid = cguid }));
        }
    }
}
