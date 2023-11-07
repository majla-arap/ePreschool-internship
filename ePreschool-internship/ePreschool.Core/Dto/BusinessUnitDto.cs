using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePreschool.Core.Dto
{
    public class BusinessUnitDto : BaseDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string IDNumber { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PostalCode { get; set; }
        public string Identifier { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public bool Active { get; set; }
        public int PreschoolId { get; set; }
    }
}
