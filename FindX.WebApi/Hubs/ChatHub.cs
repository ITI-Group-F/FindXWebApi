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

	public async Task CreatePrivateGroupForUserAsync(string userId)
	{
		await Groups.AddToGroupAsync(Context.ConnectionId, userId);
	}

	public async Task SendMessageToGroupAsync(string sender, string receiver, string message)
	{
		await Clients.Group(receiver).SendAsync("ReceiveMessage", sender, message);
		await _conversationRepository.SaveToUserChatHistoryAsync(
			new Guid(sender),
			new Guid(receiver),
			new Message
			{
				Id = Guid.NewGuid(),
				Content = message,
				SendDate = DateTime.Now,
				SenderId = new Guid(sender),
			});
	}
}
