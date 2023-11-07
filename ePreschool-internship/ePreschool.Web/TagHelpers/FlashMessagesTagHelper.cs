using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ePreschool.Web.TagHelpers
{
    [HtmlTargetElement("flash-messages")]
    public class FlashMessagesTagHelper : TagHelper
    {
        private readonly IViewComponentHelper _viewComponentHelper;

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public FlashMessagesTagHelper(IViewComponentHelper viewComponentHelper)
        {
            _viewComponentHelper = viewComponentHelper;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            ((IViewContextAware)_viewComponentHelper).Contextualize(ViewContext);

            var content = await _viewComponentHelper.InvokeAsync("FlashMessages", null);

            output.TagMode = TagMode.StartTagAndEndTag;
            output.Content.SetHtmlContent(content);
        }
    }
}
