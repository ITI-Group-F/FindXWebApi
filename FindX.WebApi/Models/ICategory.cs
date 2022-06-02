using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FindX.WebApi.Models
{
	public interface ICategory
	{
		[BsonId]
		public Guid Id { get; set; }
		public string Title { get; set; }
	}
}
