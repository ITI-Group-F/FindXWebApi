using FindX.WebApi.Models;

namespace FindX.WebApi.Repositories
{
	public interface ISubCategoryRepository
	{
		Task<SubCategory> GetSubCategoryIdAsync(string title);
	}
}
