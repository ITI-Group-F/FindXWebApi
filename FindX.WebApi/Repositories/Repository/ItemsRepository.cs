using FindX.WebApi.Models;
using FindX.WebApi.Repositories.IRepository;
using FindX.WebApi.Services;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FindX.WebApi.Repositories.Repository;


public class ItemsRepository : IItemsRepository
{
	private readonly IMongoContext _context;
	private readonly FilterDefinitionBuilder<Item> _filterBuilder = Builders<Item>.Filter;

	public ItemsRepository(IMongoContext context)
	{
		_context = context;
	}

	public async Task<IEnumerable<Item>> GetItemsAsync()
	{
		return await _context.Items
			.Find(new BsonDocument())
			.ToListAsync();
	}

	public Task<IEnumerable<Item>> GetItemsUnderSubCategoryAsync(string subCategory)
	{
		throw new NotImplementedException();
	}

	public Task<IEnumerable<Item>> GetItemsUnderSuperCategoryAsync(string superCategory)
	{
		throw new NotImplementedException();
	}
}

