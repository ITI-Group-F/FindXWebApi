using FindX.WebApi.Models.Chat;

namespace FindX.WebApi.Models.Populated
{
	public class PopulatedConversation
	{
		public Guid Id { get; set; }
		public ApplicationUser Sender { get; set; }
		public ApplicationUser Receiver { get; set; }
		public List<Message> Messages { get; set; }
	}
}
