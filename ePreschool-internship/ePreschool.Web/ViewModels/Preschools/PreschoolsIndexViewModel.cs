using ePreschool.Core.Dto;

namespace ePreschool.Web.ViewModels.Preschools
{
    public class PreschoolsIndexViewModel
    {
        public string searchFilter { get; set; }

        public List<PreschoolDto> Preschools { get; set; }
    }
}
