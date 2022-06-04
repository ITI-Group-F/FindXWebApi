using FindX.WebApi.Extenstions;
using FindX.WebApi.Models;
using FindX.WebApi.Models.Populated;
using FindX.WebApi.Repositories.IRepository;
using FindX.WebApi.Services;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FindX.WebApi.Repositories;

public class UserItemsRepository : IUserItemsRepository
{
	private readonly IMongoContext _context;
	private readonly IPopulatorRepository _populatorRepository;
	private readonly FilterDefinitionBuilder<Item> _itemFilterBuilder = Builders<Item>.Filter;
	private readonly FilterDefinitionBuilder<ApplicationUser> _userFilterBuilder = Builders<ApplicationUser>.Filter;

	public UserItemsRepository(IMongoContext context, IPopulatorRepository populatorRepository)
	{
		_context = context;
		_populatorRepository = populatorRepository;
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

	public async Task<IEnumerable<Item>> GetAllItemsAsync()
	{
		return await _context.Items
			.Find(new BsonDocument())
			.ToListAsync();
	}

	public async Task<IEnumerable<Item>> GetAllItemsForUserAsync(Guid userId)
	{
		return await _context.Items
			.Find(new BsonDocument())
			.ToListAsync();
	}

	public async Task<IEnumerable<PopulatedItem>> GetItemsForUserAsync(Guid userId)
	{
		return await _populatorRepository.GetPopulatedItemsForUserAsync(userId);
	}

	public async Task<PopulatedItem> GetItemForUserAsync(Guid userId, Guid itemId)
	{
		return await _populatorRepository.GetPopulatedItemForUserAsync(userId, itemId);
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
