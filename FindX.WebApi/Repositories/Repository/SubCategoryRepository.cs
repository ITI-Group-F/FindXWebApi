using FindX.WebApi.Models;
using FindX.WebApi.Services;
using MongoDB.Driver;

namespace FindX.WebApi.Repositories
{
	public class SubCategoryRepository : ISubCategoryRepository
	{
		private readonly IMongoContext _context;
		private readonly FilterDefinitionBuilder<SubCategory> _filterBuilder = Builders<SubCategory>.Filter;

		public SubCategoryRepository(IMongoContext context)
		{
			_context = context;
		}

		public async Task<SubCategory> GetSubCategoryIdAsync(string title)
		{
			var filter = _filterBuilder.Eq(c => c.Title, title);
			return await _context.SubCategories
				.Find(filter)
				.SingleOrDefaultAsync();
		}
	}
}
