using AutoMapper;
using ePreschool.Core.Dto;
using ePreschool.Service;
using ePreschool.Shared.Services;
using ePreschool.Shared.Services.Crypto;
using ePreschool.Shared.Services.Email;
using ePreschool.Web.Services.ActivityLogger;
using ePreschool.Web.Services.FlashMessages;
using ePreschool.Web.Services.Toastr;
using ePreschool.Web.Services.UserManager;
using ePreschool.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ePreschool.Web.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUsersService _usersService;
        private readonly IApplicationUserRoleService _applicationUserRoleService;
        private readonly IUserManager _userManager;
        private readonly IEmail _email;
        private readonly ICrypto _crypto;

        public UserController(IEmail email, IUsersService usersService, IApplicationUserRoleService applicationUserRoleService, ICrypto crypto, IUserManager userManager, IActivityLogger logger, IToastr toastr, IFlashMessages flashMessages, IMapper mapper) : base(logger, toastr, flashMessages, mapper)
        {
            _userManager = userManager;
            _email = email;
            _usersService = usersService;
            _crypto = crypto;
            _applicationUserRoleService = applicationUserRoleService;
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(NewUserViewModel newUserVM)
        {
            if (ModelState.IsValid)
            {
                newUserVM.PasswordSalt = _crypto.GenerateSalt();
                newUserVM.PasswordHash = _crypto.GenerateHash(newUserVM.Password, newUserVM.PasswordSalt);
                var newUser = Mapper.Map<ApplicationUserDto>(newUserVM);
                var model = await _usersService.AddAsync(newUser);

                return View("VerifyEmail", model);
            }
            return View("Registration", newUserVM);
        }
        public IActionResult VerifyEmail(ApplicationUserDto model)
        {
            return View(model);
        }

        public async Task SendActivationEmail(int id)
        {
            var korisnik = await _usersService.GetByIdAsync(id);
            await _email.Send("Aktiviraj racun", $"<p>Click on the link to activate account <a href=\"https://localhost:7211/User/ActivateAccount?id={id}\"><strong>ACTIVATION LINK</strong></a></p>"
                 , korisnik.Email, korisnik.UsernName);
        }

        public async Task<IActionResult> ActivateAccount(int id)
        {
            var korisnik = await _usersService.GetByIdAsync(id);
            await _usersService.ActivateUser(korisnik.Id, true);
            var UserRole = _applicationUserRoleService.AddAsync(new ApplicationUserRoleDto()
            {
                UserId = korisnik.Id,
                PreschoolId = korisnik.PreschoolId,
                BusinessUnitId = korisnik.CurrentBusinessUnitId,
                RoleId = 7
            });
            return RedirectToAction("SignIn", "Access");
        }

    }
}
