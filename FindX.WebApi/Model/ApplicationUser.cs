using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;
namespace FindX.WebApi.Model
{
    [CollectionName("Users")]
    public class ApplicationUser : MongoDbIdentityUser
    {
    }
}
