using ePreschool.Core.Enumerations;
using ePreschool.Web.Services.UserManager;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ePreschool.Web.Attributes
{
    public class AuthenticateAttribute : TypeFilterAttribute
    {
        public AuthenticateAttribute(params Role[] roles) : base(typeof(AuthorizationFilter))
        {
            Arguments = new object[] { roles };
        }
    }

    public class AuthorizationFilter : IAuthorizationFilter
    {
        private readonly Role[] _roles;
        private readonly IUserManager _userManager;

        public AuthorizationFilter(Role[] roles, IUserManager userManager)
        {
            _roles = roles;
            _userManager = userManager;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!_userManager.IsSignedIn())
            {
                context.Result = new RedirectToActionResult("SignIn", "Access", null);
                return;
            }          

            //context.Result = new RedirectToActionResult("Error", "Index", new { id = 401 });
        }
    }
}
