using AutoMapper;

using ePreschool.Core.Dto;
using ePreschool.Core.Enumerations;
using ePreschool.Web.Services.ActivityLogger;
using ePreschool.Web.Services.FlashMessages;
using ePreschool.Web.Services.Toastr;

using Microsoft.AspNetCore.Mvc;

namespace ePreschool.Web.Controllers
{
    public class BaseController : Controller
    {

        protected readonly IToastr Toastr;
        protected readonly IFlashMessages FlashMessages;
        protected readonly IMapper Mapper;
        protected readonly IActivityLogger ActivityLogger;

        public BaseController(IActivityLogger logger, IToastr toastr, IFlashMessages flashMessages, IMapper mapper)
        {
            ActivityLogger = logger;
            Toastr = toastr;
            FlashMessages = flashMessages;
            Mapper = mapper;
        }

        protected async Task LogAsync(LogDto log, bool disableToastr = false, bool disableFlashMessages = true)
        {
            await ActivityLogger.CreateLog(log);

            if (!disableToastr)
                switch (log.Type)
                {
                    case LogType.SystemError:
                        Toastr.Danger(log.Message);
                        break;
                    case LogType.Deleted:
                        Toastr.Warning(log.Message);
                        break;
                    default:
                        Toastr.Success(log.Message);
                        break;
                }

            if (!disableFlashMessages)
                FlashMessages.SetMessage(new FlashMessage
                {
                    Title = log.Title,
                    Message = log.Message,
                    Status = new[] { LogType.Created, LogType.Modified, LogType.Deleted }.Contains(log.Type) ? FlashMessageStatus.Success : FlashMessageStatus.Failure
                });
        }
    }
}
