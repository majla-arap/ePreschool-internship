using Microsoft.AspNetCore.Html;

namespace ePreschool.Web.Services.Toastr
{
    public interface IToastr
    {
        void Success(string message);
        void Danger(string message);
        void Warning(string message);
        IHtmlContent Display();
    }
}
