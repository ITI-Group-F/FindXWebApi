using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;
namespace FindX.WebApi.Model
{
	[CollectionName("users")]
	public class ApplicationUser : MongoIdentityUser<Guid>
	{
	}
}
