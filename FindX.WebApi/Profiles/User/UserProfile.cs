using AutoMapper;
using FindX.WebApi.DTOs.User;
using FindX.WebApi.Models;

namespace FindX.WebApi.Profiles.User;

public class UserProfile : Profile
{
	public UserProfile()
	{
		CreateMap<ApplicationUser, UserReadDto>();
		CreateMap<UserUpdateDto, ApplicationUser>();
	}
}
