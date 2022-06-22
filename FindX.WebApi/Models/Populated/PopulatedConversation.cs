using FindX.WebApi.DTOs.User;
using FindX.WebApi.Models.Chat;

namespace FindX.WebApi.Models.Populated;

public class PopulatedConversation
{
	public Guid Id { get; set; }
	public ChatUserReadDto Sender { get; set; }
	public ChatUserReadDto Receiver { get; set; }
	public List<Message> Messages { get; set; }
}
