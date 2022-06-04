using FindX.WebApi.Models;
using MongoDB.Libmongocrypt;

namespace FindX.WebApi.DTOs
{
	public class ItemReadDTO
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime Date { get; set; }
		public string Location { get; set; }
		public bool IsLost { get; set; }
		public ICollection<byte[]> Images { get; set; } = new HashSet<byte[]>();

		public ApplicationUser User { get; set; }
		public SuperCategory SubCategory { get; set; }
	}
}
