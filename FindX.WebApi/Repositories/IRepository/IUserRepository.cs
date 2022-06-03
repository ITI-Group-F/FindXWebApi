using FindX.WebApi.Models;

namespace FindX.WebApi.Repositories.IRepository
{
    public interface IUserRepository
    {
        public Task<IEnumerable<ApplicationUser>> GetAllUsers();
    }
}
