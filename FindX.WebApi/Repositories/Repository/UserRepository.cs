
using FindX.WebApi.Models;
using FindX.WebApi.Repositories.IRepository;
using FindX.WebApi.Services;
using MongoDB.Driver;
using FindX.WebApi.DTOs.User;
using Microsoft.AspNetCore.Identity;

namespace FindX.WebApi.Repositories.Repository
{
    public class UserRepository : IUserRepository
    {
		private readonly IMongoContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly FilterDefinitionBuilder<ApplicationUser> _userFilterBuilder = Builders<ApplicationUser>.Filter;

		public UserRepository(IMongoContext context, UserManager<ApplicationUser> userManager)
		{
			_context = context;
            _userManager = userManager;
        }

        public Task<bool> CheckEmailAsync(Guid userID, string email)
        {
            if (_context.Users.Find(x => x.Id != userID && x.Email == email).FirstOrDefault() != null)
            {
                return Task.FromResult(true);
            }
            else {
                return Task.FromResult(false);
            }
        }

        public async Task<ApplicationUser> UpdateUserAsync(UserUpdateDto user)
        {
            
            var filter = _userFilterBuilder.Eq(x => x.Id, user.Id);           
            var update = await _context.Users.FindOneAndUpdateAsync(filter,
                Builders<ApplicationUser>.Update.Set(x => x.FirstName, user.FirstName)
                .Set(x => x.LastName, user.LastName)
                .Set(x => x.Email, user.Email)
                .Set(x => x.PhoneNumber, user.Phone)
                .Set(x => x.Phone, user.Phone)                
                .Set(x => x.NormalizedEmail, user.Email.ToUpper()));
                string HashedPassword = _userManager.PasswordHasher.HashPassword(update, user.Password);
            var updatePassword = await _context.Users.FindOneAndUpdateAsync(filter,
                Builders<ApplicationUser>.Update.Set(x => x.PasswordHash, HashedPassword));                        
            return update;
        }
    }
}
