using Microsoft.AspNetCore.Identity;

namespace ePreschool.Core.Entities.Identity
{
    public class ApplicationUserRole : IdentityUserRole<int>, IBaseEntity
    {
        public int Id { get; set; }
        public int? PreschoolId { get; set; }
        public Preschool Preschool { get; set; }
        public int? BusinessUnitId { get; set; }
        public BusinessUnit BusinessUnit { get; set; }
        //public ApplicationUser User { get; set; }
        //public ApplicationRole Role { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public bool IsDeleted {
            get; set;
        }
    }
}
