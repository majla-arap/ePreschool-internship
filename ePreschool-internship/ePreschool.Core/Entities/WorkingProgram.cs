using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePreschool.Core.Entities
{
    public class WorkingProgram : BaseEntity
    {
        public string Name { get; set; }
        public int NumberOfHours { get; set; }
        public string Description { get; set; }
    }
}
