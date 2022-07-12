using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FindX.WebApi.DTOs;
using FindX.WebApi.Services;
using System.Text.RegularExpressions;

namespace FindX.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
	private readonly IAuthenticateService _Authenticate;

	public AuthenticationController(IAuthenticateService Authenticate)
	{
		_Authenticate = Authenticate;
	}

	[HttpPost]
	[Route("login")]
	public async Task<IActionResult> Login(LoginDto model)
	{
		var result = await _Authenticate.Login(model);
		if (result != null)
		{			
			return Ok(result);
		}
		return BadRequest("Wrong user name or password");
	}

	[HttpPost]
	[Route("register-user")]
	public async Task<IActionResult> Register(RegisterDto model)
	{
		if (!Regex.IsMatch(model.Password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$")) {
			return BadRequest("Incorrect password format (Minimum eight characters," +
                " at least one uppercase letter, one lowercase letter, one number and one special character is required)");
		}
		var result = await _Authenticate.Register(model);
		if (result != null)
		{
			return Ok(result);
        }
        return BadRequest("User with the same email exists !!");

    }

    [Authorize(Roles = "Admin")]
	[HttpPost]
	[Route("register-admin")]
	public async Task<IActionResult> RegisterAdmin(RegisterDto model)
	{
		if (!Regex.IsMatch(model.Password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$"))
		{
			return BadRequest("Incorrect password format (Minimum eight characters," +
				" at least one uppercase letter, one lowercase letter, one number and one special character is required)");
		}
		var result = await _Authenticate.RegisterAdmin(model);
		if (result != null)
		{
			return Ok(result);
		}
		return BadRequest("User with the same email exists !!");
	}

	[Authorize(Roles = "Admin")]
	[HttpPost]
	[Route("create-role")]
	public async Task<IActionResult> CreateRole(string name)
	{
		var result = await _Authenticate.CreateRole(name);
		if (result != null)
		{
			return Ok(result);
		}
		return BadRequest("Role already exists");
	}

}
