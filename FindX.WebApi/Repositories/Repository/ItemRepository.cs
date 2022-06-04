using FindX.WebApi.Extenstions;
using FindX.WebApi.Models;
using FindX.WebApi.Models.Populated;
using FindX.WebApi.Services;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FindX.WebApi.Repositories
{
	public class ItemRepository : IItemRepository
	{
		private readonly IMongoContext _context;
		private readonly FilterDefinitionBuilder<Item> _itemFilterBuilder = Builders<Item>.Filter;
		private readonly FilterDefinitionBuilder<ApplicationUser> _userFilterBuilder = Builders<ApplicationUser>.Filter;

		public ItemRepository(IMongoContext context)
		{
			_context = context;
		}

		public async Task CreateItemAsync(Guid userId, Item item)
		{
			if (item is null)
			{
				throw new ArgumentNullException(nameof(item));
			}
			item.UserId = userId;
			await _context.Items.InsertOneAsync(item);
		}

		public async Task DeleteItemAsync( Guid userId, Guid itemId)
		{
			var filter = Builders<Item>.Filter.Eq(x => x.Id, itemId);
			filter &= Builders<Item>.Filter.Eq(x => x.UserId, userId);
			await _context.Items.DeleteOneAsync(filter);
		}

			public async Task<IEnumerable<Item>> GetAllItemsAsync()
		{
			return await _context.Items
				.Find(new BsonDocument())
				.ToListAsync();
		}

		public async Task<IEnumerable<PopulatedItem>> GetItemsForUserAsync(Guid userId)
		{
			return await GetPopulatedItemsAsync(userId);
		}

		public async Task<bool> IsUserExist(Guid userId)
		{
			var filter = _userFilterBuilder.Eq(x => x.Id, userId);
			var user = await _context.Users
				.Find(filter)
				.SingleOrDefaultAsync();
			return await Task.FromResult(user is not null);
		}

		public async Task UpdateItemAsync(Guid userId, Item item)
		{
			item.UserId = userId;
			var filter = _itemFilterBuilder.Eq(x => x.UserId, userId);
			await _context.Items.ReplaceOneAsync(filter, item);
		}

		private async Task<IEnumerable<PopulatedItem>> GetPopulatedItemsAsync(Guid userId)
		{
			var query =
				from item in _context.Items.AsQueryable()
				join user in _context.Users.AsQueryable()
					on item.UserId equals user.Id
				where item.UserId == userId
				join sub in _context.SubCategories.AsQueryable()
					on item.SubCategoryId equals sub.Id
				join sup in _context.SuperCategories.AsQueryable()
					on item.SuperCategoryId equals sup.Id
				select new PopulatedItem
				{
					Id = item.Id,
					Title = item.Title,
					Description = item.Description,
					Date = item.Date,
					Location = item.Location,
					IsLost = item.IsLost,
					IsClosed = item.IsClosed,
					Images = item.Images,
					User = user,
					SubCategory = sub,
					SuperCategory = sup,
				};
			return await query.ToListAsync();
		}


    }
}
