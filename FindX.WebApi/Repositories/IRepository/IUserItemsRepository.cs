using FindX.WebApi.Models;

namespace FindX.WebApi.Repositories
{
	public interface IUserItemsRepository
	{
		Task<IEnumerable<Item>> GetAllItemsAsync();
		Task<IEnumerable<Item>> GetItemsForUserAsync(Guid userId);
		Task<Item> GetItemForUserAsync(Guid userId, Guid itemId);
		Task CreateItemAsync(Item item);
		Task UpdateItemAsync(Item item);
		Task DeleteItemAsync(Guid userId, Guid itemId);
		Task<bool> IsUserExist(Guid userId);
	}
}
