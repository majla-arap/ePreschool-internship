using AutoMapper;

using ePreschool.Core.Dto;
using ePreschool.Core.Enumerations;
using ePreschool.Shared.Services;

using ePreschool.Web.Services.ActivityLogger;
using ePreschool.Web.Services.FlashMessages;
using ePreschool.Web.Services.Toastr;

using Microsoft.AspNetCore.Mvc;
using ePreschool.Shared.Resources;
using ePreschool.Shared.Extensions;

namespace ePreschool.Web.Controllers
{
    public class LanguageController : BaseController
    {

        private readonly ILanguageManager _languageManager;

        public LanguageController(IActivityLogger activityLogger, IFlashMessages flashMessages,
          IToastr toastr, ILanguageManager languageManager, IMapper mapper) :
            base(activityLogger, toastr, flashMessages, mapper)
        {
            _languageManager = languageManager;
        }
        public async Task<IActionResult> Change(string name)
        {
            _languageManager.Set(name);

            await LogAsync(new LogDto(LogType.Information, Translations.Language, null, Translations.Changed, Translations.LanguageChangedSuccess), true);

            var referer = Request.Headers["Referer"].ToString();
            if (!referer.IsSet())
                return RedirectToAction("Index", "Home");

            return Redirect(referer);
        }
    }
}
