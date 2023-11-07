using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePreschool.Core.Entities
{
    public class ParentChild : BaseEntity
    {
        public int ParentId { get; set; }
        public Parent Parent { get; set; }
        public int ChildId { get; set; }
        public Child Child { get; set; }
    }
}
