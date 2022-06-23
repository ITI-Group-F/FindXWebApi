using FindX.WebApi.DTOs.User;
using FindX.WebApi.Models.Chat;

namespace FindX.WebApi.Models.Populated;

public class ConversationLookUp : Conversation
{
	public List<ApplicationUser> Sender { get; set; }
	public List<ApplicationUser> Receiver { get; set; }
}
