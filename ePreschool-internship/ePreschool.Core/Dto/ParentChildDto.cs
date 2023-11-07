using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePreschool.Core.Dto
{
    public class ParentChildDto : BaseDto
    {
        public int ParentId { get; set; }
        public ParentDto Parent { get; set; }
        public int ChildId { get; set; }
        public ChildDto Child { get; set; }
    }
}
