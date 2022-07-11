using FindX.WebApi.Models;
using FindX.WebApi.DTOs.User;

namespace FindX.WebApi.Repositories.IRepository
{
    public interface IUserRepository
    {
        Task<ApplicationUser> UpdateUserAsync(UserUpdateDto user);
        Task<bool> CheckEmailAsync(Guid userID, string email);
    }
}
