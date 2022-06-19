using FindX.WebApi.Models;

namespace FindX.WebApi.Repositories.IRepository
{
	public interface IUserItemsRepository
	{
		Task<IEnumerable<Item>> GetItemsForUserAsync(Guid userId);
		Task<Item> GetItemForUserAsync(Guid userId, Guid itemId);
		Task CreateItemAsync(Item item);
		Task UpdateItemAsync(Item item);
		Task DeleteItemAsync(Guid userId, Guid itemId);
		Task<bool> IsUserExistAsync(Guid userId);
	}
}
