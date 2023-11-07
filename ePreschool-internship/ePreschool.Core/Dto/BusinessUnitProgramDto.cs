using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePreschool.Core.Dto
{
    public class BusinessUnitProgramDto : BaseDto
    {
        public int BusinessUnitId { get; set; }
        public BusinessUnitDto BusinessUnit { get; set; }
        public int ProgramId { get; set; }
        public WorkingProgramDto Program { get; set; }
    }
}
