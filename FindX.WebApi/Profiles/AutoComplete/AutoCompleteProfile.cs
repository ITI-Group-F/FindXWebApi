using AutoMapper;
using FindX.WebApi.DTOs;
using FindX.WebApi.Models;

namespace FindX.WebApi.Profiles.AutoComplete;

public class AutoCompleteProfile : Profile
{
	public AutoCompleteProfile()
	{
		CreateMap<Item, AutoCompleteReadDto>();
	}
}
