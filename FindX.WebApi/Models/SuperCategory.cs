using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDbGenericRepository.Attributes;

namespace FindX.WebApi.Model
{
	[CollectionName("superCategory")]
	public class SuperCategory : ICategory
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
		public ICategory[] Subcategories { get; set; }
	}
}
