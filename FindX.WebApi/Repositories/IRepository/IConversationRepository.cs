using FindX.WebApi.Models.Chat;

namespace FindX.WebApi.Repositories.IRepository;

public interface IConversationRepository
{
	Task<Guid> CreateConversation(Guid senderId, Guid receiverId);
	Task AddMessageToConversation(Message message, Guid convId);
	Task StartConversation(Guid senderId, Guid receiverId, Message message);
}
