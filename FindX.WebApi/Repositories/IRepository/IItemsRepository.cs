﻿using FindX.WebApi.Models;

namespace FindX.WebApi.Repositories.IRepository
{
	public interface IItemsRepository
	{
		Task<IEnumerable<Item>> GetItemsAsync();
		Task<IEnumerable<Item>> GetItemsUnderSubCategoryAsync(string subCategory);
		Task<IEnumerable<Item>> GetItemsUnderSuperCategoryAsync(string superCategory);
	}
}