using ePreschool.Web.Services.FlashMessages;

using Microsoft.AspNetCore.Mvc;

namespace ePreschool.Web.ViewComponents
{
    [ViewComponent(Name = "FlashMessages")]
    public class FlashMessagesViewComponent : ViewComponent
    {
        private readonly IFlashMessages _flashMessages;

        public FlashMessagesViewComponent(IFlashMessages flashMessages)
        {
            _flashMessages = flashMessages;
        }

        public IViewComponentResult Invoke()
        {
            var flashMessages = _flashMessages.GetMessages();

            return View("Index", flashMessages);
        }
    }
}
