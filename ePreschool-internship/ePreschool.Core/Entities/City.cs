namespace ePreschool.Core.Entities
{
    public class City : BaseEntity
	{
		public string Name { get; set; }
		public bool IsFavorite { get; set; }
		public int CountryId { get; set; }
		public Country Country { get; set; }
	}
}
