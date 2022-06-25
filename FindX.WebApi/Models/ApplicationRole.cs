using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;

namespace FindX.WebApi.Models;

[CollectionName("roles")]
public class ApplicationRole : MongoIdentityRole<Guid>
{
	public ApplicationRole(string roleName) : base(roleName)
	{
	}
	public ApplicationRole()
	{
	}
}
