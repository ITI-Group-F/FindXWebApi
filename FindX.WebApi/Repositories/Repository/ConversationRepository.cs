using AutoMapper;
using FindX.WebApi.DTOs.Chat;
using FindX.WebApi.DTOs.User;
using FindX.WebApi.Extenstions;
using FindX.WebApi.Models;
using FindX.WebApi.Models.Chat;
using FindX.WebApi.Models.Populated;
using FindX.WebApi.Repositories.IRepository;
using FindX.WebApi.Services;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FindX.WebApi.Repositories.Repository
{
	public class ConversationRepository : IConversationRepository
	{
		private readonly IMongoContext _context;
		private readonly IMapper _mapper;
		private readonly FilterDefinitionBuilder<ApplicationUser> _userFilterBuilder = Builders<ApplicationUser>.Filter;
		private readonly FilterDefinitionBuilder<Conversation> _convFilterBuilder = Builders<Conversation>.Filter;

		public ConversationRepository(IMongoContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
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

		public async Task SaveToUserChatHistoryAsync(Guid senderId, Guid receiverId, Message message)
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

			var conversationsFilter = (
				_convFilterBuilder.Eq(c => c.SenderId, senderId)
				& _convFilterBuilder.Eq(c => c.ReceiverId, receiverId))
				| (
				_convFilterBuilder.Eq(c => c.SenderId, receiverId)
				| _convFilterBuilder.Eq(c => c.ReceiverId, senderId));

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

		public async Task<IEnumerable<PopulatedConversationReadDto>> GetUserConversationsAsync(Guid userId)
		{
			var convFilter = _convFilterBuilder.Eq(c => c.SenderId, userId)
				| _convFilterBuilder.Eq(c => c.ReceiverId, userId);

			var lookConvs = await _context.Conversations
				.Aggregate()
				.Match(convFilter)
				.Lookup<Conversation, ApplicationUser, ConversationLookUp>
				(_context.Users,
				x => x.SenderId,
				x => x.Id,
				x => x.Sender)
				.Lookup<ConversationLookUp, ApplicationUser, ConversationLookUp>
				(_context.Users,
				x => x.ReceiverId,
				x => x.Id,
				x => x.Receiver)
				.ToListAsync();

			var convs = _mapper.Map<List<PopulatedConversationReadDto>>(lookConvs);
			for (int i = 0; i < lookConvs.Count; i++)
			{
				convs[i].Sender = _mapper.Map<UserReadDto>(lookConvs[i].Sender[0]);
				convs[i].Receiver = _mapper.Map<UserReadDto>(lookConvs[i].Receiver[0]);
			}

			return convs;

			//var convs = await _context.Conversations
			//	.Find(convFilter)
			//	.ToListAsync();
			//var popConvs = _mapper.Map<List<ConversationLookUp>>(convs);
			//var cashed = new Dictionary<Guid, ChatUserReadDto>();
			//for (int i = 0; i < convs.Count; i++)
			//{
			//	if (cashed.ContainsKey(convs[i].SenderId))
			//	{
			//		popConvs[i].Sender = cashed[convs[i].SenderId];
			//	}
			//	else
			//	{
			//		var userFilter = _userFilterBuilder.Eq(u => u.Id, convs[i].SenderId);
			//		var user = await _context.Users.Find(userFilter).SingleOrDefaultAsync();
			//		var chatUser = _mapper.Map<ChatUserReadDto>(user);
			//		popConvs[i].Sender = chatUser;
			//		cashed[convs[i].SenderId] = chatUser;
			//	}
			//	if (cashed.ContainsKey(convs[i].ReceiverId))
			//	{
			//		popConvs[i].Receiver = cashed[convs[i].SenderId];
			//	}
			//	else
			//	{
			//		var userFilter = _userFilterBuilder.Eq(u => u.Id, convs[i].ReceiverId);
			//		var user = await _context.Users.Find(userFilter).SingleOrDefaultAsync();
			//		var chatUser = _mapper.Map<ChatUserReadDto>(user);
			//		popConvs[i].Receiver = chatUser;
			//		cashed[convs[i].ReceiverId] = chatUser;
			//	}
			//}
			//return popConvs;
		}
	}
}
