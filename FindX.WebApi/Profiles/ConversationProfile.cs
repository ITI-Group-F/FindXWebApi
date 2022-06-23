using AutoMapper;
using FindX.WebApi.DTOs.Chat;
using FindX.WebApi.Models.Chat;
using FindX.WebApi.Models.Populated;

namespace FindX.WebApi.Profiles;

public class ConversationProfile : Profile
{
	public ConversationProfile()
	{
		CreateMap<ConversationLookUp, PopulatedConversationReadDto>()
			.ForMember(x => x.Receiver, opt => opt.Ignore())
			.ForMember(x => x.Sender, opt => opt.Ignore());
	}
}
