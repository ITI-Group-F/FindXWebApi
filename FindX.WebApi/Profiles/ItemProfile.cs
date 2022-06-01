using AutoMapper;
using FindX.WebApi.Model;

namespace FindX.WebApi.DTOs.Profiles
{
	public class ItemProfile : Profile
	{
		public ItemProfile()
		{
			CreateMap<ItemUpdateDTO, Item>();
			CreateMap<ItemCreateDTO, Item>();
			CreateMap<Item, ItemReadDTO>();
		}
	}
}
