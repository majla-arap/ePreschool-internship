using ePreschool.Core.Dto;
using ePreschool.Service;
using ePreschool.Shared.Constants;
using ePreschool.Shared.Extensions;
using ePreschool.Shared.Services.Crypto;

namespace ePreschool.Web.Services.UserManager
{
    public interface IUserManager
    {
        ApplicationUserDto Get();
        Task SignInAsync(string email, string password);
        void SignOut();
        bool IsSignedIn();
    }


    public class UserManager : IUserManager
    {

        private readonly ICrypto _crypto;
        private readonly IUsersService _userService;
        private readonly ISession _session;

        public UserManager(ICrypto crypto, IUsersService userService, IHttpContextAccessor httpContextAccessor)
        {
            _crypto = crypto;
            _userService = userService;
            _session = httpContextAccessor.HttpContext.Session;
        }

        public ApplicationUserDto Get()
        {
            return _session.GetObject<ApplicationUserDto>(SessionKeys.User);
        }

        public async Task SignInAsync(string username, string password)
        {
            var user = await _userService.GetByUsername(username);
            if (user == null)
                throw new UserNotFoundException();

            if (!_crypto.Verify(user.PasswordHash, user.PasswordSalt, password))
                throw new WrongCredentialsException(user);

            _session.SetObject<ApplicationUserDto>(SessionKeys.User, user);
        }

        public void SignOut()
        {
            _session.Remove(SessionKeys.User);
        }

        public bool IsSignedIn()
        {
            return _session.ContainsKey(SessionKeys.User);
        }
    }

    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(string message = null) : base(message) { }
    }

    public class WrongCredentialsException : Exception
    {
        public ApplicationUserDto User { get; set; }

        public WrongCredentialsException(ApplicationUserDto user, string message = null) : base(message)
        {
            User = user;
        }
    }
}

