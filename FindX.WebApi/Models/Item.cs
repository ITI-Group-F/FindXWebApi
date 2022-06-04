using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Libmongocrypt;
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
		public ICollection<byte[]> Images { get; set; } = new HashSet<byte[]>();

		public Guid UserId { get; set; }
		public Guid SubCategoryId { get; set; }
		public Guid SuperCategoryId { get; set; }
	}
}
