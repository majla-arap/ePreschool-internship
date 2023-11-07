using ePreschool.Web.Attributes;

using Microsoft.AspNetCore.Mvc.Razor;

namespace ePreschool.Web.Utilities.Extensions
{
    public static class RazorPageBaseExtensions
    {
        public static string Title(this RazorPageBase page, string title = null)
        {
            if (title != null)
                page.ViewContext.ViewData["Title"] = title;

            return page.ViewContext.ViewData["Title"]?.ToString();
        }
        public static MenuItem? MenuItem(this RazorPageBase page, MenuItem? menuItem = null)
        {
            if (menuItem != null)
                page.ViewContext.ViewData["MenuItem"] = menuItem;

            return (MenuItem?)page.ViewContext.ViewData["MenuItem"];
        }
    }
}
