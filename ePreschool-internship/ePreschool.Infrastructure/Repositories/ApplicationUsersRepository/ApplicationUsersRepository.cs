using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dapper;

using ePreschool.Core.Dto;
using ePreschool.Core.Entities;
using ePreschool.Core.Entities.Identity;
using ePreschool.Infrastructure.Repositories;

namespace ePreschool.Infrastructure.Reporsitories
{

    public class ApplicationUsersRepository : BaseRepository<ApplicationUser, int>, IApplicationUsersRepository
    {
        public ApplicationUsersRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }

        public ApplicationUser GetByUsername_OLD(string username)
        {
            return _dbSet.Where(x => x.UserName == username).FirstOrDefault();
        }
        public async Task<ApplicationUser> GetByUsername(string pUserName)
        {

            var query = "SELECT * FROM fn_users_getbyusername(@pUserName);" +
                               "SELECT * FROM fn_city_getbyusername(@pUserName);";

            var result = await DbConnection.QueryMultipleAsync(query, new DynamicParameters(new { pUserName }));

            var user = await result.ReadFirstOrDefaultAsync<ApplicationUser>();
            if (user != null)
                user.City = await result.ReadFirstOrDefaultAsync<City>();

            return user;
        }
        public async Task ActivateUser(int userId, bool active)
        {
            var query = "SELECT * FROM fn_users_activateUser(@userId,@active);";
            await DbConnection.QueryMultipleAsync(query, new DynamicParameters(new { userId = userId, active = active }));

        }
    }
}
