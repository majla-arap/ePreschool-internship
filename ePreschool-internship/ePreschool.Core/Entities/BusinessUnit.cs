namespace ePreschool.Core.Entities
{
    public class BusinessUnit : BaseEntity
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
        public Preschool Preschool { get; set; }
    }
}
