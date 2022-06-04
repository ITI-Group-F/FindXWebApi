using FindX.WebApi.Models;
using FindX.WebApi.Models.Populated;

namespace FindX.WebApi.Repositories
{
	public interface IItemRepository
	{
		Task<IEnumerable<Item>> GetAllItemsAsync();
		Task<IEnumerable<PopulatedItem>> GetItemsForUserAsync(Guid userId);
		Task CreateItemAsync(Guid userId, Item item);
		Task UpdateItemAsync(Guid userId, Item item);
		Task DeleteItemAsync(Guid itemId);



		Task<bool> IsUserExist(Guid userId);

	}
}
