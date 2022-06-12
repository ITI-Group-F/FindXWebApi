using FindX.WebApi.Extenstions;
using FindX.WebApi.Models;
using FindX.WebApi.Repositories.IRepository;
using FindX.WebApi.Services;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FindX.WebApi.Repositories.Repository;

public class UserItemsRepository : IUserItemsRepository
{
	private readonly IMongoContext _context;
	private readonly FilterDefinitionBuilder<Item> _itemFilterBuilder = Builders<Item>.Filter;
	private readonly FilterDefinitionBuilder<ApplicationUser> _userFilterBuilder = Builders<ApplicationUser>.Filter;

	public UserItemsRepository(IMongoContext context)
	{
		_context = context;
	}

	public async Task CreateItemAsync(Item item)
	{
		if (item is null)
		{
			throw new ArgumentNullException(nameof(item));
		}
		await _context.Items.InsertOneAsync(item);
	}

	public async Task DeleteItemAsync(Guid userId, Guid itemId)
	{
		var filter = Builders<Item>.Filter.Eq(x => x.Id, itemId);
		filter &= Builders<Item>.Filter.Eq(x => x.UserId, userId);
		await _context.Items.DeleteOneAsync(filter);
	}

	public async Task<IEnumerable<Item>> GetAllItemsForUserAsync(Guid userId)
	{
		return await _context.Items
			.Find(new BsonDocument())
			.ToListAsync();
	}

	public async Task<IEnumerable<Item>> GetItemsForUserAsync(Guid userId)
	{
		var filter = _itemFilterBuilder.Eq(x => x.UserId, userId);
		return await _context.Items
			.Find(filter)
			.ToListAsync();
	}

	public async Task<Item> GetItemForUserAsync(Guid userId, Guid itemId)
	{
		var filter = _itemFilterBuilder.Eq(x => x.UserId, userId) &
			_itemFilterBuilder.Eq(x => x.Id, itemId);
		return await _context.Items
			.Find(filter)
			.SingleOrDefaultAsync();
	}

	public async Task<bool> IsUserExist(Guid userId)
	{
		var filter = _userFilterBuilder.Eq(x => x.Id, userId);
		var user = await _context.Users
			.Find(filter)
			.SingleOrDefaultAsync();
		return await Task.FromResult(user is not null);
	}

	public async Task UpdateItemAsync(Item item)
	{
		var filter = _itemFilterBuilder.Eq(x => x.UserId, item.UserId);
		await _context.Items.ReplaceOneAsync(filter, item);
	}
}
