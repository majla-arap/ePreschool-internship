using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePreschool.Core.Entities
{
    public class BusinessUnitProgram : BaseEntity
    {
        public int BusinessUnitId { get; set; }
        public BusinessUnit BusinessUnit { get; set; }
        public int ProgramId { get; set; }
        public WorkingProgram Program { get; set; }

    }
}
