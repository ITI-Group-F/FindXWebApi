using FindX.WebApi.Extenstions;
using FindX.WebApi.Models;
using FindX.WebApi.Models.Chat;
using FindX.WebApi.Repositories.IRepository;
using FindX.WebApi.Services;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FindX.WebApi.Repositories.Repository
{
	public class ConversationRepository : IConversationRepository
	{
		private readonly IMongoContext _context;
		private readonly FilterDefinitionBuilder<ApplicationUser> _userFilterBuilder = Builders<ApplicationUser>.Filter;
		private readonly FilterDefinitionBuilder<Conversation> _convFilterBuilder = Builders<Conversation>.Filter;

		public ConversationRepository(IMongoContext context)
		{
			_context = context;
		}

		private async Task AddMessageToConversation(Message message, Guid convId)
		{
			var filter = _convFilterBuilder.Eq(c => c.Id, convId);
			var conv = await _context.Conversations.Find(filter).SingleOrDefaultAsync();
			conv.Messages.Add(message);
			await _context.Conversations.ReplaceOneAsync(filter, conv);
		}

		private async Task<Guid> CreateConversation(Guid senderId, Guid receiverId, Message message)
		{
			var conv = new Conversation
			{
				Id = Guid.NewGuid(),
				SenderId = senderId,
				ReceiverId = receiverId,
				Messages = new List<Message> { message }
			};
			await _context.Conversations.InsertOneAsync(conv);
			return conv.Id;
		}

		public async Task SaveToUserChatHistory(Guid senderId, Guid receiverId, Message message)
		{
			var senderFilter = _userFilterBuilder.Eq(u => u.Id, senderId);
			var sender = await _context.Users
				.Find(senderFilter)
				.SingleOrDefaultAsync();
			if (sender is null)
			{
				return;
			}
			//var userConversations =
			//	from convId in sender.Conversations.AsQueryable()
			//	join conv in _context.Conversations.AsQueryable()
			//	on convId equals conv.Id
			//	select conv;

			var conversationsFilter = _convFilterBuilder.Eq(c => c.SenderId, senderId)
				& _convFilterBuilder.Eq(c => c.ReceiverId, receiverId);

			var userConversation = await _context.Conversations
				.Find(conversationsFilter)
				.SingleOrDefaultAsync();

			if (userConversation is null)
			{
				var convId = await CreateConversation(senderId, receiverId, message);
				return;
			}
			await AddMessageToConversation(message, userConversation.Id);
		}
	}
}
