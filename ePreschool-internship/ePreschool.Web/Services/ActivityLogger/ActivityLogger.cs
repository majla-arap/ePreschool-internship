using ePreschool.Core.Dto;
using ePreschool.Service;
using ePreschool.Web.Services.UserManager;

namespace ePreschool.Web.Services.ActivityLogger
{
    public class ActivityLogger : IActivityLogger
    {
        private readonly ILogService _logService;
        private readonly IUserManager _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ActivityLogger(ILogService logService, IUserManager userManager, IHttpContextAccessor httpContextAccessor)
        {
            _logService = logService;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task CreateLog(LogDto logDto)
        {

            try
            {
                var request = _httpContextAccessor.HttpContext?.Request;
                if (request != null)
                {
                    logDto.ReferrerUrl = request.Headers["Referer"].ToString();
                    logDto.CurrentUrl = request.Path.ToString();
                    logDto.Controller = (string)request.RouteValues["Controller"];
                    logDto.Action = (string)request.RouteValues["Action"];
                }

                var user = _userManager.Get();
                logDto.UserId = user?.Id;

                await _logService.AddAsync(logDto);
            }
            catch
            {
                //Ignored
            }
        }
    }
}
