using FindX.WebApi.DTOs;
using FindX.WebApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FindX.WebApi.Services
{
	public class AuthenticateService : IAuthenticateService
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<ApplicationRole> _roleManager;
		private readonly IConfiguration _configuration;

		public AuthenticateService(
				UserManager<ApplicationUser> userManager,
				RoleManager<ApplicationRole> roleManager,
				IConfiguration configuration)
		{
			_userManager = userManager;
			_roleManager = roleManager;
			_configuration = configuration;
		}

		public async Task<UserToken> Login(LoginDto model)
		{
			var user = await _userManager.FindByEmailAsync(model.Email);
			if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
			{
				return await GenerateJwtToken(user);
			}
			return null;
		}

		public async Task<UserToken> Register(RegisterDto model)
		{
			var userExists = await _userManager.FindByEmailAsync(model.Email);
			if (userExists != null)
			{
				return null;
			}
			List<Guid> roles = _roleManager.Roles.Where(r => r.Name == "User").Select(r => r.Id).ToList();
			ApplicationUser user = new()
			{
				Roles = roles,
				Email = model.Email,
				SecurityStamp = Guid.NewGuid().ToString(),
				UserName = model.Username
			};
			var result = await _userManager.CreateAsync(user, model.Password);
			if (!result.Succeeded)
			{ return null; }
			var token = await GenerateJwtToken(user);
			token.Message = "User created successfully!";
			return token;
		}

		public async Task<UserToken> RegisterAdmin(RegisterDto model)
		{
			var userExists = await _userManager.FindByNameAsync(model.Username);
			if (userExists != null)
			{ return null; }
			List<Guid> roles = _roleManager.Roles.Where(r => r.Name == "Admin").Select(r => r.Id).ToList();

			ApplicationUser user = new()
			{
				Roles = roles,
				Email = model.Email,
				SecurityStamp = Guid.NewGuid().ToString(),
				UserName = model.Username
			};
			var result = await _userManager.CreateAsync(user, model.Password);
			if (!result.Succeeded)
			{ return null; }

			if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
				await _roleManager.CreateAsync(new ApplicationRole(UserRoles.Admin));
			if (!await _roleManager.RoleExistsAsync(UserRoles.User))
				await _roleManager.CreateAsync(new ApplicationRole(UserRoles.User));

			if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
			{
				await _userManager.AddToRoleAsync(user, UserRoles.Admin);
			}
			if (await _roleManager.RoleExistsAsync(UserRoles.Admin))
			{
				await _userManager.AddToRoleAsync(user, UserRoles.User);
			}
			var token = await GenerateJwtToken(user);
			token.Message = "Admin created successfully!";
			return token;
		}

		public async Task<object> CreateRole(string name)
		{
			IdentityResult result = await _roleManager.CreateAsync(new ApplicationRole() { Name = name });
			if (result.Succeeded)
			{
				return new { message = $"{name} Role created" };
			}
			return null;
		}

		public JwtSecurityToken GetToken(List<Claim> authClaims)
		{
			var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:PrivateKey"]));

			var token = new JwtSecurityToken(
					expires: DateTime.Now.AddHours(3),
					claims: authClaims,
					signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
					);
			return token;
		}

		private async Task<UserToken> GenerateJwtToken(ApplicationUser user)
		{
			var userRoles = await _userManager.GetRolesAsync(user);
			var authClaims = new List<Claim>
				{
						new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
						new Claim("userId", user.Id.ToString()),
						new Claim("userName", user.UserName),
						new Claim("email", user.Email),
				};

			foreach (var userRole in userRoles)
			{
				authClaims.Add(new Claim("roles", userRole));
			}

			var token = GetToken(authClaims);

			return new UserToken
			{
				Token = new JwtSecurityTokenHandler().WriteToken(token),
				Expiration = token.ValidTo
			};
		}
	}

	public class UserToken
	{
		public string Token { get; set; }
		public DateTime Expiration { get; set; }
		public string Message { get; set; }
	}
}
