using FindX.WebApi.Models;
using MongoDB.Libmongocrypt;

namespace FindX.WebApi.DTOs
{
	public class ItemCreateDTO
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime Date { get; set; }
		public string Location { get; set; }
		public bool IsLost { get; set; }
		public ICollection<byte[]> Images { get; set; } = new HashSet<byte[]>();
		public string SubCategory { get; set; }
		public string SuperCategory { get; set; }
	}
}
