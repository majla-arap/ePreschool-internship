using ePreschool.Core.Dto;
using ePreschool.Core.Entities.Identity;
using ePreschool.Infrastructure.Repositories;

namespace ePreschool.Infrastructure.Reporsitories
{
    public interface IApplicationUsersRepository : IBaseRepository<ApplicationUser, int>
    {
        Task<ApplicationUser> GetByUsername(string username);
        ApplicationUser GetByUsername_OLD (string username);
        Task ActivateUser(int userId, bool active);
    }
}
