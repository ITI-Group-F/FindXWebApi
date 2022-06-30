using MongoDB.Bson.Serialization.Attributes;
using MongoDbGenericRepository.Attributes;
using System.ComponentModel.DataAnnotations;

namespace FindX.WebApi.Models
{
	[CollectionName("items")]
	public class Item
	{
		public Guid Id { get; set; }
		[Required]
		public string Title { get; set; }
		public string Description { get; set; }
		[Required]
		[DataType(DataType.Date)]
		public DateTime Date { get; set; }
		[Required]
		public string Longitude { get; set; }
		[Required]
		public string Latitude { get; set; }
		[Required]
		public string Location { get; set; }
		[Required]
		public bool IsLost { get; set; }
		public bool IsClosed { get; set; }
		public ICollection<byte[]> Images { get; set; } = new HashSet<byte[]>();
		[Required]
		public string SubCategory { get; set; }
		[Required]
		public string SuperCategory { get; set; }
		[Required]
		public Guid UserId { get; set; }

		[BsonIgnoreIfNull]
		public string Brand { get; set; }
		[BsonIgnoreIfNull]
		public string Model { get; set; }
		[BsonIgnoreIfDefault]
		public int ModelYear { get; set; }
		[BsonIgnoreIfNull]
		public string Color { get; set; }
		[BsonIgnoreIfDefault]
		public int Age { get; set; }
	}
}
