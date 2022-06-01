using AutoMapper;
using FindX.WebApi.Model;
using FindX.WebApi.Models.Populated;

namespace FindX.WebApi.Profiles
{
	public class PopulatedItemProfile : Profile
	{
		public PopulatedItemProfile()
		{
			CreateMap<Item, PopulatedItems>();
		}
	}
}
