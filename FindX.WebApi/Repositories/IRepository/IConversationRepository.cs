using FindX.WebApi.Models.Chat;
using FindX.WebApi.Models.Populated;

namespace FindX.WebApi.Repositories.IRepository;

public interface IConversationRepository
{
	Task SaveToUserChatHistoryAsync(Guid senderId, Guid receiverId, Message message);
	Task<IEnumerable<PopulatedConversation>> GetUserConversationsAsync(Guid userId);
}
