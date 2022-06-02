using AspNetCore.Identity.MongoDbCore.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDbGenericRepository.Attributes;
namespace FindX.WebApi.Models
{
	[CollectionName("users")]
	public class ApplicationUser : MongoIdentityUser<Guid>
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Phone { get; set; }
	}
}
