using FindX.WebApi.Model;
using System.Collections;

namespace FindX.WebApi.Repositories
{
	public interface IItemRepository
	{
		Task<IEnumerable<Item>> GetAllItemsAsync();
		Task<IEnumerable<Item>> GetItemsForUserAsync(Guid userId);
		Task CreateItemAsync(Guid userId, Item item);
		Task UpdateItemAsync(Guid userId, Item item);
		Task DeleteItemAsync(Guid userId, Guid itemId);

		Task<bool> SaveChangesAsync();
		Task<bool> IsUserExist(Guid userId);
	}
}
