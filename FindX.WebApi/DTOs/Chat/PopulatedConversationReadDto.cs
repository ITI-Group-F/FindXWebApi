using FindX.WebApi.DTOs.User;
using FindX.WebApi.Models.Chat;

namespace FindX.WebApi.DTOs.Chat;

public class PopulatedConversationReadDto
{
	public Guid Id { get; set; }
	public UserReadDto Sender { get; set; }
	public UserReadDto Receiver { get; set; }
	public List<Message> Messages { get; set; }
}
