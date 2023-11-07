using ePreschool.Core.Dto;

namespace ePreschool.Web.ViewModels.Preschools
{
    public class PreschoolsAddViewModel
    {
        public PreschoolDto Preschool { get; set; } = new PreschoolDto();
        public IFormFile File { get; set; }

    }
}
