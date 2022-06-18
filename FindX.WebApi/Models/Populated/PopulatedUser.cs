using AspNetCore.Identity.MongoDbCore.Models;
using FindX.WebApi.Models.Chat;

namespace FindX.WebApi.Models.Populated;

public class PopulatedUser : MongoIdentityUser<Guid>
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string Phone { get; set; }
	public IEnumerable<Conversation> Conversations { get; set; }
}
