using ePreschool.Core.Dto;
using ePreschool.Core;

namespace ePreschool.Service
{
    public interface IUsersService : IBaseService<ApplicationUserDto>
    {
        Task<ApplicationUserDto> GetByUsername(string username);
        ApplicationUserDto GetByUsername_OLD(string username);
        Task ActivateUser(int userId, bool active);
    }
}
