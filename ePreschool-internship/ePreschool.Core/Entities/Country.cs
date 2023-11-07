namespace ePreschool.Core.Entities
{
    public class Country : BaseEntity
	{
		public string Name { get; set; }
		public string Abbreviation { get; set; }
		public bool IsFavorite { get; set; }
	}
}
