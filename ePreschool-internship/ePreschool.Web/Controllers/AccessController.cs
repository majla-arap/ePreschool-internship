using AutoMapper;

using ePreschool.Core.Dto;
using ePreschool.Core.Enumerations;
using ePreschool.Shared.Resources;
using ePreschool.Web.Services.ActivityLogger;
using ePreschool.Web.Services.FlashMessages;
using ePreschool.Web.Services.Toastr;
using ePreschool.Web.Services.UserManager;
using ePreschool.Web.ViewModels;

using Microsoft.AspNetCore.Mvc;

namespace ePreschool.Web.Controllers
{
    public class AccessController : BaseController
    {

        private readonly IUserManager _userManager;
        
        public AccessController(IUserManager userManager, IActivityLogger logger, IToastr toastr, IFlashMessages flashMessages, IMapper mapper) : base(logger, toastr, flashMessages, mapper)
        {
            _userManager = userManager;
        }

        public IActionResult SignIn()
        {
            return View(new AccessSignInViewModel() { UserName="admin",Password="admin"});
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(AccessSignInViewModel signInViewModel)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    await _userManager.SignInAsync(signInViewModel.UserName, signInViewModel.Password);
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception exception)
            {
                var e = exception as WrongCredentialsException;

                await LogAsync(new LogDto(LogType.UnsuccessfulSignIn, nameof(ApplicationUserDto), e?.User?.Id, Translations.Error, Translations.WrongCredentials, e));

            }
            return View(signInViewModel);


        }

        [HttpGet]
        public new IActionResult SignOut()
        {
            _userManager.SignOut();

            return RedirectToAction("SignIn");
        }
    }
}
