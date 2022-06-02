namespace FindX.WebApi.Models.Populated
{
	public class PopulatedSubCat
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
		public SuperCategory SuperCategory { get; set; }
	}
}
