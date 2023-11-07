namespace ePreschool.Web.Services.FlashMessages
{
    public interface IFlashMessages
    {
        void Success(string title, string message);
        void Failure(string title, string message);
        void Clear();
        List<FlashMessage> GetMessages();
        void SetMessage(FlashMessage flashMessage);
    }

    public class FlashMessage
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public FlashMessageStatus Status { get; set; }
    }

    public enum FlashMessageStatus
    {
        Success,
        Failure
    }
}
