using ePreschool.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePreschool.Core.Dto
{
    public class ParentDto : BaseDto
    {
        public int? UserId { get; set; }
        public ApplicationUserDto User { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool Employed { get; set; }
        public string? EmployerName { get; set; }
        public int? EmployerCityId { get; set; }
        public CityDto? EmployerCity { get; set; }
        public string? EmployerAdress { get; set; }
        public string? EmployerPhoneNumber { get; set; }
        public string JobDescription { get; set; }
        public EducationLevel EducationLevel { get; set; }

    }
}
