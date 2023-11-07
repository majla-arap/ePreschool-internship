using Dapper;
using ePreschool.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePreschool.Infrastructure.Repositories
{
    public class ParentRepository : BaseRepository<Parent, int>, IParentRepository
    {
        public ParentRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
        public async Task<IEnumerable<dynamic>> GetParentByEmail(string mail)
        {
            var query = "SELECT * FROM fn_parent_getparentbyemail(@mail);";

            return await DbConnection.QueryAsync(query,
                          new DynamicParameters(new { mail = mail }));
        }
    }
}
