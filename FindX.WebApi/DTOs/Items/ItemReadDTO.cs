using FindX.WebApi.Models;

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
		//public bool IsClosed { get; set; }
		public ICollection<byte[]> Images { get; set; } = new HashSet<byte[]>();
		public string SubCategory { get; set; }
		public string SuperCategory { get; set; }
		public Guid UserId { get; set; }
	}
}
