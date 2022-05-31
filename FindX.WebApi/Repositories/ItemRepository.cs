using FindX.WebApi.Model;
using FindX.WebApi.Services;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FindX.WebApi.Repositories
{
	public class ItemRepository : IItemRepository
	{
		private readonly IMongoContext _context;

		public ItemRepository(IMongoContext context)
		{
			_context = context;
		}

		public Task CreateItemAsync(Guid userId, Item item)
		{
			throw new NotImplementedException();
		}

		public Task DeleteItemAsync(Guid userId, Guid itemId)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<Item>> GetAllItemsAsync()
		{
			return await _context.Items
				.Find(new BsonDocument()).ToListAsync();
		}

		public Task<IEnumerable<Item>> GetItemsForUserAsync(Guid userId)
		{
			throw new NotImplementedException();
		}

		public Task<bool> IsUserExist(Guid userId)
		{
			throw new NotImplementedException();
		}

		public Task<bool> SaveChangesAsync()
		{
			throw new NotImplementedException();
		}

		public Task UpdateItemAsync(Guid userId, Item item)
		{
			throw new NotImplementedException();
		}
	}
}
