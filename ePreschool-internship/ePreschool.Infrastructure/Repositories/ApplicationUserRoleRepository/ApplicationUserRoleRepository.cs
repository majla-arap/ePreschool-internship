using ePreschool.Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePreschool.Infrastructure.Repositories
{
    public class ApplicationUserRoleRepository : BaseRepository<ApplicationUserRole, int>, IApplicationUserRoleRepository
    {
        public ApplicationUserRoleRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
