namespace ePreschool.Core.Dto
{
    public class PreschoolDto : BaseDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string WebPage { get; set; }
        public string IDNumber { get; set; }
        public string TaxNumber { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PostalCode { get; set; }
        public string Logo { get; set; }
        public string LogoThumbnail { get; set; }
        public string Identifier { get; set; }
        public bool Active { get; set; }
        public bool InVatSystem { get; set; }
        public bool VatIncludedInPrice { get; set; }
        public ICollection<BusinessUnitDto> BusinessUnits { get; set; }

    }
}
