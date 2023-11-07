using ePreschool.Core.Dto;
using ePreschool.Core.Enumerations;

namespace ePreschool.Web.ViewModels.Children
{
    public class ChildAddViewModel
    {
        public ChildDto Child { get; set; }
        public ParentDto Mother { get; set; }
        public ParentDto Father { get; set; }
        
    }
}
