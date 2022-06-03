using FindX.WebApi.Models;
using FindX.WebApi.Repositories.IRepository;
using FindX.WebApi.Services;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FindX.WebApi.Repositories.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoContext _context;
        public UserRepository(IMongoContext context) {
            _context = context;
        }
        public async Task<IEnumerable<ApplicationUser>> GetAllUsers()
        {
            return await _context.Users.Find( _ => true).ToListAsync();
            
        }
    }
}
