﻿using FindX.WebApi.Models;
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

	public async Task<IEnumerable<Item>> GetItemsUnderSubCategoryAsync(string subCategory)
	{
		var Filter = _filterBuilder.Eq(i => i.SubCategory, subCategory);
		return await _context.Items.Find(Filter).ToListAsync();
		
		 
    }

	public async Task<IEnumerable<Item>> GetItemsUnderSuperCategoryAsync(string superCategory)
	{
		var Filter = _filterBuilder.Eq(i => i.SuperCategory, superCategory);
		return await _context.Items.Find(Filter).ToListAsync();

	}
}

