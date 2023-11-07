using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePreschool.Core.Entities.Identity
{
    public class ApplicationRole : IdentityRole<int>, IBaseEntity
    {
        public int? RoleLevel { get; set; }
        public bool SignInAllowed { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<ApplicationUserRole> Roles { get; set; }


    }
}
