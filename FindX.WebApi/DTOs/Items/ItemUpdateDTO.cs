using FindX.WebApi.Models;
using MongoDB.Libmongocrypt;

namespace FindX.WebApi.DTOs
{
	public class ItemUpdateDTO
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime Date { get; set; }
		public string Location { get; set; }
		public bool IsLost { get; set; }
		public ICollection<byte[]> Images { get; set; } = new HashSet<byte[]>();
		public Guid UserId { get; set; }
		public string SubCategory { get; set; }
	}
}
