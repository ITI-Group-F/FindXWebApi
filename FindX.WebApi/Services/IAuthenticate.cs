using FindX.WebApi.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace FindX.WebApi.Services
{
    public interface IAuthenticate
    {
        public Task<object> Login([FromBody] LoginModel model);
        public Task<object> Register([FromBody] RegisterModel model);
        public Task<object> RegisterAdmin([FromBody] RegisterModel model);
        public JwtSecurityToken GetToken(List<Claim> authClaims);
        public Task<object> CreateRole([Required] string name);

    }
}
