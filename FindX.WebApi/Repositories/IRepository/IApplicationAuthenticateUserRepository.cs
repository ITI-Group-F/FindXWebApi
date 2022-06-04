using FindX.WebApi.Models;

namespace FindX.WebApi.Repositories.IRepository
{
    public interface IApplicationAuthenticateUserRepository
    {
        public Task<string> CheckLogIn(User user);        
        public Task<string> CreateToken(User usr);        
    }
}
