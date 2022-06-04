using FindX.WebApi.Models;
using FindX.WebApi.Repositories.IRepository;
using FindX.WebApi.Services;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
namespace FindX.WebApi.Repositories.Repository
{
    public class ApplicationUserAuthenticateRepository :
        IApplicationAuthenticateUserRepository
    {
        private readonly IMongoContext _context;
        private readonly FilterDefinitionBuilder<ApplicationUser> _userFilterBuilder = Builders<ApplicationUser>.Filter;
        private readonly IConfiguration _configuration;
        public ApplicationUserAuthenticateRepository(IMongoContext context,IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<string> CheckLogIn(User usr)
        {
            try
            {
                var user = await _context.Users.Find(x => x.Email == usr.Email && x.PasswordHash == usr.PasswordHash)
                    .SingleOrDefaultAsync();
                if (user == null) return null;
                return await CreateToken(usr);
            }
            catch (Exception)
            {               
                return null;
            }
        }

      
        public async Task<string> CreateToken(User usr)
        {
            var tokenhandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_configuration.GetSection("PrivateKey").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                    {
                            new Claim(ClaimTypes.Email, usr.Email),
                            new Claim(ClaimTypes.Role, usr.role)
                        }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenhandler.CreateToken(tokenDescriptor);

            return await Task.FromResult(tokenhandler.WriteToken(token));
        }
    }
}
