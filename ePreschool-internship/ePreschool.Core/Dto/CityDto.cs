namespace ePreschool.Core.Dto
{
    public class CityDto : BaseDto {
        public string Name { get; set; }
        public bool IsFavorite { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public CountryDto Country { get; set; }

    }
}
