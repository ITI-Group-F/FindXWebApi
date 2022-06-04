using FindX.WebApi.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace FindX.WebApi.Services
{
	public interface IAuthenticateService
	{
		public Task<UserToken> Login([FromBody] LoginDto model);
		public Task<UserToken> Register([FromBody] RegisterDto model);
		public Task<UserToken> RegisterAdmin([FromBody] RegisterDto model);
		public JwtSecurityToken GetToken(List<Claim> authClaims);
		public Task<object> CreateRole([Required] string name);

	}
}
