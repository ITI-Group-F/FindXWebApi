using MongoDB.Libmongocrypt;

namespace FindX.WebApi.Models.Populated;

public class PopulatedItem
{
	public Guid Id { get; set; }
	public string Title { get; set; }
	public string Description { get; set; }
	public DateTime Date { get; set; }
	public string Location { get; set; }
	public bool IsLost { get; set; }
	public bool IsClosed { get; set; }
	public ICollection<byte[]> Images { get; set; } = new HashSet<byte[]>();

	public ApplicationUser User { get; set; }
	public SubCategory SubCategory { get; set; }
	public SuperCategory SuperCategory { get; set; }
}
