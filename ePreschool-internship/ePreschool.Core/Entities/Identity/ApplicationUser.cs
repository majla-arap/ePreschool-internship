
using Microsoft.AspNetCore.Identity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePreschool.Core.Entities.Identity
{
    public class ApplicationUser : IdentityUser<int>, IBaseEntity
    {
     
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfilePhoto { get; set; }
        public string ProfilePhotoThumbnail { get; set; }
        public string Address { get; set; }
        public string AlternativePhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Gender Gender { get; set; }

        public int? CityId { get; set; }
        public City City { get; set; }
        public string PostCode { get; set; }

        public int? PreschoolId { get; set; }
        public Preschool Preschool { get; set; }
        public int? CurrentBusinessUnitId { get; set; }
        public BusinessUnit CurrentBusinessUnit { get; set; }
        public string JobDescription { get; set; }
        public ICollection<ApplicationUserRole> Roles { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
        public bool Active { get; set; } = false;
        
        public string PasswordSalt { get; set; }


    }
}
