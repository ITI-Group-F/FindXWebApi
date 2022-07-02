using FindX.WebApi.Models;

namespace FindX.WebApi.Repositories.IRepository;

public interface ISearchRepository
{
	public Task<IEnumerable<Item>> SearchFinderAsync(string query);
}
