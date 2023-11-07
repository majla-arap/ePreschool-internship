using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePreschool.Core.Dto
{
    public class ApplicationUserRoleDto : BaseDto
    {
        public int Id { get; set; }
        public int? PreschoolId { get; set; }
        public PreschoolDto Preschool { get; set; }
        public int? BusinessUnitId { get; set; }
        public BusinessUnitDto BusinessUnit { get; set; }
        public int? UserId { get; set; }
        public int? RoleId { get; set; }
    }
}
