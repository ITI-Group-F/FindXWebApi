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

		public async Task CreateItemAsync(Guid userId, Item item)
		{
			item.UserId = userId;
            await _context.Items.InsertOneAsync(item);
            
		}

		public Task DeleteItemAsync(Guid itemId)
		{
            var filter = Builders<Item>.Filter.Eq(x => x.Id, itemId);
            return _context.Items.DeleteOneAsync(filter);
		}

		public async Task<IEnumerable<Item>> GetAllItemsAsync()
		{
			return await _context.Items
				.Find(new BsonDocument()).ToListAsync();
		}

		public async Task<IEnumerable<Item>> GetItemsForUserAsync(Guid userId)
		{
            var filter = Builders<Item>.Filter.Eq(x => x.UserId, userId);
            
            
            return await _context.Items.Find(filter).ToListAsync();
            
		}

		public Task<bool> IsUserExist(Guid userId) //item repository ??
		{
            //if not equal null return true
            var filter = Builders<Item>.Filter.Eq(x => x.UserId, userId);

            return filter == null ? Task.FromResult(false) : Task.FromResult(true);
        
		}

		

		public async Task UpdateItemAsync(Guid userId, Item item)
		{

            var filter = Builders<Item>.Filter.Eq(x => x.UserId, userId);
             await _context.Items.ReplaceOneAsync(filter, item);
        }
	}
}
