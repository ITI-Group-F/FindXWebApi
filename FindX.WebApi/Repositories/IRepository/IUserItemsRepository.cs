using FindX.WebApi.Models;
using FindX.WebApi.Models.Populated;

namespace FindX.WebApi.Repositories
{
	public interface IUserItemsRepository
	{
		Task<IEnumerable<Item>> GetAllItemsAsync();
		Task<IEnumerable<PopulatedItem>> GetItemsForUserAsync(Guid userId);
		Task<PopulatedItem> GetItemForUserAsync(Guid userId, Guid itemId);
		Task CreateItemAsync(Item item);
		Task UpdateItemAsync(Item item);
		Task DeleteItemAsync(Guid userId, Guid itemId);
		Task<bool> IsUserExist(Guid userId);
	}
}
