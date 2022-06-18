using FindX.WebApi.Models.Chat;
using FindX.WebApi.Repositories.IRepository;
using Microsoft.AspNetCore.SignalR;

namespace FindX.WebApi.Hubs;

public class ChatHub : Hub
{
	private readonly IConversationRepository _conversationRepository;

	public ChatHub(IConversationRepository conversationRepository)
	{
		_conversationRepository = conversationRepository;
	}

	public override Task OnConnectedAsync()
	{
		Groups.AddToGroupAsync(Context.ConnectionId, Context.User.Identity.Name);
		return base.OnConnectedAsync();
	}

	public Task SendMessageToGroupAsync(string sender, string receiver, string message)
	{
		_conversationRepository.StartConversation(
			new Guid(sender),
			new Guid(receiver),
			new Message
			{
				Content = message,
				SendDate = DateTime.Now,
				IsSender = true,
			});
		return Clients.Group(receiver).SendAsync("ReceiveMessage", sender, message);
	}
}
