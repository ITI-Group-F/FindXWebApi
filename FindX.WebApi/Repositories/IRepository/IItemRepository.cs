using FindX.WebApi.Model;
using FindX.WebApi.Models.Populated;
using System.Collections;

namespace FindX.WebApi.Repositories
{
	public interface IItemRepository
	{
		Task<IEnumerable<Item>> GetAllItemsAsync();
		Task<IEnumerable<Item>> GetItemsForUserAsync(Guid userId);
		Task CreateItemAsync(Guid userId, Item item);
		Task UpdateItemAsync(Guid userId, Item item);
		Task DeleteItemAsync(Guid itemId);

		Task<bool> IsUserExist(Guid userId);

	}
}
