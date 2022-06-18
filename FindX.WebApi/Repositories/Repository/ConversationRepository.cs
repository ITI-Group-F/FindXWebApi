using FindX.WebApi.Models;
using FindX.WebApi.Models.Chat;
using FindX.WebApi.Repositories.IRepository;
using FindX.WebApi.Services;
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

		public async Task AddMessageToConversation(Message message, Guid convId)
		{
			var filter = _convFilterBuilder.Eq(c => c.Id, convId);
			var conv = await _context.Conversations.Find(filter).SingleOrDefaultAsync();
			conv.Messages.Append(message);
			await _context.Conversations.ReplaceOneAsync(filter, conv);
		}

		public async Task<Guid> CreateConversation(Guid senderId, Guid receiverId)
		{
			var conv = new Conversation
			{
				Id = new Guid(),
				SenderId = senderId,
				ReceiverId = receiverId
			};
			await _context.Conversations.InsertOneAsync(conv);
			return conv.Id;
		}

		public async Task StartConversation(Guid senderId, Guid receiverId, Message message)
		{
			var senderFilter = _userFilterBuilder.Eq(u => u.Id, senderId);
			var sender = await _context.Users
				.Find(senderFilter)
				.SingleOrDefaultAsync();
			if (sender is null)
			{
				return;
			}
			var userConversations =
				from userConv in sender.Conversations.AsQueryable()
				join conv in _context.Conversations.AsQueryable()
				on userConv equals conv.Id
				select conv as Conversation;
			var conList = userConversations.ToList();
			var res = conList.Where(c => c.ReceiverId == receiverId).SingleOrDefault();
			if (res is null)
			{
				var convId = await CreateConversation(senderId, receiverId);
				await AddMessageToConversation(message, convId);
			}
			else
			{
				await AddMessageToConversation(message, res.Id);
			}
		}
	}
}
