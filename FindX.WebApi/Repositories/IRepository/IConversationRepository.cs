using FindX.WebApi.Models.Chat;

namespace FindX.WebApi.Repositories.IRepository;

public interface IConversationRepository
{
	Task SaveToUserChatHistory(Guid senderId, Guid receiverId, Message message);
}
