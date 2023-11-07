using ePreschool.Web.Attributes;

using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ePreschool.Web.TagHelpers
{
    [HtmlTargetElement(Attributes = "menu-item")]
    public class ActiveMenuItemTagHelper : TagHelper
    {
        [HtmlAttributeName("menu-item")]
        public MenuItem MenuItem { get; set; }

        [HtmlAttributeName("current-menu-item")]
        public MenuItem? CurrentMenuItem { get; set; }

        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (CurrentMenuItem == null)
            {
                if (ViewContext.ActionDescriptor is ControllerActionDescriptor controller)
                {
                    var controllerAttributes = controller.ControllerTypeInfo.GetCustomAttributes(typeof(MenuItemAttribute), true);
                    if (controllerAttributes.Length > 0)
                    {
                        CurrentMenuItem = ((MenuItemAttribute)controllerAttributes.First()).MenuItem;
                    }
                    if (CurrentMenuItem == null)
                    {
                        var actionAttributes = controller.MethodInfo.GetCustomAttributes(typeof(MenuItemAttribute), true);
                        if (controllerAttributes.Length > 0)
                        {
                            CurrentMenuItem = ((MenuItemAttribute)actionAttributes.First()).MenuItem;
                        }
                    }
                }
            }

            if (CurrentMenuItem == null)
                return;

            var currentClasses = string.Empty;

            if (output.Attributes.TryGetAttribute("class", out var attribute))
                currentClasses = attribute.Value.ToString();

            output.Attributes.SetAttribute("class", $"{currentClasses} {(MenuItem == CurrentMenuItem ? "active" : string.Empty)}");
        }
    }
}
