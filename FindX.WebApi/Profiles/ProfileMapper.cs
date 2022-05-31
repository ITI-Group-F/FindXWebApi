using AutoMapper;
using FindX.WebApi.Model;

namespace FindX.WebApi.DTOs.Profiles
{
	public class ProfileMapper : Profile
	{
		public ProfileMapper()
		{
			CreateMap<ItemUpdateDTO, Item>();
			CreateMap<ItemCreateDTO, Item>();
			CreateMap<Item, ItemReadDTO>();
		}
	}
}
