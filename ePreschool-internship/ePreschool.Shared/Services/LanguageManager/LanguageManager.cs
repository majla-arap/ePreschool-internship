using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePreschool.Shared.Services
{
    public class LanguageManager : ILanguageManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LanguageManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string Get()
        {
            return _httpContextAccessor.HttpContext?.Request.Cookies[CookieRequestCultureProvider.DefaultCookieName];
        }

        public void Set(string newLanguage)
        {
            if (string.IsNullOrEmpty(newLanguage))
                return;

            _httpContextAccessor.HttpContext?.Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(newLanguage)), new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddYears(1)
            });
        }
    }
}
