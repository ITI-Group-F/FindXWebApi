using AutoMapper;
using FindX.WebApi.DTOs.Populated;
using FindX.WebApi.Models.Populated;

namespace FindX.WebApi.Profiles
{
	public class PopulatedItemProfile : Profile
	{
		public PopulatedItemProfile()
		{
			CreateMap<PopulatedItem, PopulatedItemReadDto>();
		}
	}
}
