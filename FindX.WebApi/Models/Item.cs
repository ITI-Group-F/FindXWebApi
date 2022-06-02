using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDbGenericRepository.Attributes;

namespace FindX.WebApi.Models
{
	[CollectionName("items")]
	public class Item
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime Date { get; set; }
		public string Location { get; set; }
		public bool IsLost { get; set; }
		public bool IsClosed { get; set; }
		public ICollection<string> Images { get; set; } = new HashSet<string>();

		public Guid UserId { get; set; }
		public Guid SubCategoryId { get; set; }
		public Guid SuperCategoryId { get; set; }
	}
}
