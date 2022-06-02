using FindX.WebApi.Models;
using MongoDB.Bson.Serialization.Attributes;
using MongoDbGenericRepository.Attributes;

namespace FindX.WebApi.Models
{
	[CollectionName("subCategories")]
	public class SubCategory : ICategory
	{
		public Guid Id { get; set; }
		public string Title { get; set; }
		public Guid SuperCategoryId { get; set; }
	}
}
