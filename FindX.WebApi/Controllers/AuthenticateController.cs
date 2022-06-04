using FindX.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FindX.WebApi.DTOs;
using FindX.WebApi.Services;

namespace FindX.WebApi.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController:ControllerBase
    {
        private readonly IAuthenticate _Authenticate;



        public AuthenticateController(IAuthenticate Authenticate)
        {
            _Authenticate = Authenticate;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
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
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var result = await _Authenticate.Register(model);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("User maybe exists or incorrect password format");
        }
        
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        {
            var result = await _Authenticate.RegisterAdmin(model);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("User maybe exists or incorrect password format");
        }
                       
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [Route("create-role")]
        public async Task<IActionResult> CreateRole([Required] string name)
        {
            var result = await _Authenticate.CreateRole(name);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Role already exists");
        }

    }
}
