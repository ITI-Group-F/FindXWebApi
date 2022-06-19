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

	public async Task SendMessageToGroupAsync(string sender, string receiver, string message)
	{
		await _conversationRepository.SaveToUserChatHistory(
			new Guid(sender),
			new Guid(receiver),
			new Message
			{
				Id = Guid.NewGuid(),
				Content = message,
				SendDate = DateTime.Now,
				SenderId = new Guid(sender),
			});
		await Clients.Group(receiver).SendAsync("ReceiveMessage", sender, message);
	}
}
