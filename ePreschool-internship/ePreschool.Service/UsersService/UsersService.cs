using AutoMapper;

using ePreschool.Core.Dto;
using ePreschool.Core.Entities.Identity;
using ePreschool.Infrastructure.Reporsitories;
using ePreschool.Infrastructure.UnitOfWork;

namespace ePreschool.Service
{

    public class UsersService : BaseService<ApplicationUser, ApplicationUserDto>, IUsersService
    {
        IApplicationUsersRepository _userRepository;

        public UsersService(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
            _currentRepository = _userRepository = ((UnitOfWork)unitOfWork)._usersRepository;
        }     
        public ApplicationUserDto GetByUsername_OLD(string username)
        {
            return _mapper.Map<ApplicationUserDto>(_userRepository.GetByUsername_OLD(username));
        }

        public async Task<ApplicationUserDto> GetByUsername(string username)
        {
            return _mapper.Map<ApplicationUserDto>(await _userRepository.GetByUsername(username));
        }

        public async Task ActivateUser(int userId, bool active)
        {
            await _userRepository.ActivateUser(userId, active);
        }
    }
}
