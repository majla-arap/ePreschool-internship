using ePreschool.Shared.Constants;
using ePreschool.Web.Utilities.Extensions;

using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace ePreschool.Web.Services.FlashMessages
{
    public class FlashMessages : IFlashMessages
    {
        private readonly ITempDataDictionary _tempData;

        public FlashMessages(IHttpContextAccessor httpContextAccessor, ITempDataDictionaryFactory tempDataDictionaryFactory)
        {
            _tempData = tempDataDictionaryFactory.GetTempData(httpContextAccessor.HttpContext);
        }

        public void Success(string title, string message)
        {
            SetMessage(new FlashMessage
            {
                Status = FlashMessageStatus.Success,
                Title = title,
                Message = message
            });
        }

        public void Failure(string title, string message)
        {
            SetMessage(new FlashMessage
            {
                Status = FlashMessageStatus.Failure,
                Title = title,
                Message = message
            });
        }

        public List<FlashMessage> GetMessages()
        {
            return _tempData.GetObject<List<FlashMessage>>(FlashMessageKeys.MainKey) ?? new List<FlashMessage>();
        }
        public void Clear()
        {
            _tempData.Clear();
        }

        public void SetMessage(FlashMessage flashMessage)
        {
            var messages = GetMessages();
            messages.Add(flashMessage);
            _tempData.SetObject(FlashMessageKeys.MainKey, messages);
        }
    }
}
