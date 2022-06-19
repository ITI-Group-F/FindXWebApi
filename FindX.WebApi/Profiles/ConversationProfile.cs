using AutoMapper;
using FindX.WebApi.Models.Chat;
using FindX.WebApi.Models.Populated;

namespace FindX.WebApi.Profiles;

public class ConversationProfile : Profile
{
	public ConversationProfile()
	{
		CreateMap<Conversation, PopulatedConversation>();
	}
}
