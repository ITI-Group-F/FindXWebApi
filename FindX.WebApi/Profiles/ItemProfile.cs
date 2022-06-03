using AutoMapper;
using FindX.WebApi.Models;
using FindX.WebApi.Models.Populated;

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
