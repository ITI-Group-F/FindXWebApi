using FindX.WebApi.Model;
using FindX.WebApi.Models.Populated;
using FindX.WebApi.Services;
using Microsoft.EntityFrameworkCore;
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

		public Task DeleteItemAsync(Guid itemId)
		{
			var filter = Builders<Item>.Filter.Eq(x => x.Id, itemId);
			return _context.Items.DeleteOneAsync(filter);
		}

		public async Task<IEnumerable<Item>> GetAllItemsAsync()
		{
			return await _context.Items
				.Find(new BsonDocument())
				.ToListAsync();
		}

		public async Task<IEnumerable<Item>> GetItemsForUserAsync(Guid userId)
		{
			var filter = _itemFilterBuilder.Eq(x => x.UserId, userId);
			return await _context.Items.Find(filter).ToListAsync();
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

		private async Task<IEnumerable<PopulatedItems>> GetPopulatedItemsAsync(Guid userId = default)
		{
			IQueryable<PopulatedItems>? query = null;
			if (userId == default)
			{
				query =
					from item in _context.Items.AsQueryable()
					join user in _context.Users.AsQueryable()
						on item.UserId equals user.Id
					select new PopulatedItems
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
						SubCategoryId = item.SubCategoryId,
					};
			}
			else
			{
				query =
					from item in _context.Items.AsQueryable()
					join user in _context.Users.AsQueryable()
						on item.UserId equals user.Id
					where user.Id == userId
					select new PopulatedItems
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
						SubCategoryId = item.SubCategoryId,
					};
			}

			return await query.ToListAsync();
		}
	}
}
