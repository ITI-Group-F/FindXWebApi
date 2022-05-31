
using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;

namespace FindX.WebApi.Model
{
	[CollectionName("roles")]
	public class ApplicationRole : MongoIdentityRole<Guid>
	{
	}
}
