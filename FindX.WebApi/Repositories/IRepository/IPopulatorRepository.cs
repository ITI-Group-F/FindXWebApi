using FindX.WebApi.Models.Populated;

namespace FindX.WebApi.Repositories.IRepository
{
	public interface IPopulatorRepository
	{
		Task<IEnumerable<PopulatedItem>> GetPopulatedItemsForUserAsync(Guid userId);
		Task<IEnumerable<PopulatedItem>> GetPopulatedItemsAsync();
		Task<PopulatedItem> GetPopulatedItemForUserAsync(Guid userId, Guid itemId);
	}
}
