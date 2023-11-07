using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ePreschool.Core.Dto;

namespace ePreschool.Core.Dto
{
    public class ApplicationUserDto : BaseDto
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
        public CityDto City { get; set; }
        public string PostCode { get; set; }

        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }

        public string UsernName { get; set; }
        public string Email{ get; set; }


        public int? PreschoolId { get; set; }
        public PreschoolDto Preschool { get; set; }
        public int? CurrentBusinessUnitId { get; set; }
        public BusinessUnitDto CurrentBusinessUnit { get; set; }
        public string JobDescription { get; set; }
        public ICollection<ApplicationUserRoleDto> Roles { get; set; }

        public string FirstLastName => $"{FirstName} {LastName}";
    }
}
