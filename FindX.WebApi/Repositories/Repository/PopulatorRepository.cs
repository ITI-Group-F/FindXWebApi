using FindX.WebApi.Extenstions;
using FindX.WebApi.Models.Populated;
using FindX.WebApi.Repositories.IRepository;
using FindX.WebApi.Services;
using MongoDB.Driver;

namespace FindX.WebApi.Repositories.Repository
{
	public class PopulatorRepository : IPopulatorRepository
	{
		private readonly IMongoContext _context;

		public PopulatorRepository(IMongoContext context)
		{
			_context = context;
		}

		public async Task<PopulatedItem> GetPopulatedItemForUserAsync(Guid userId, Guid itemId)
		{
			var query =
				from item in _context.Items.AsQueryable()
				join user in _context.Users.AsQueryable()
					on item.UserId equals user.Id
				join sub in _context.SubCategories.AsQueryable()
					on item.SubCategoryId equals sub.Id
				join sup in _context.SuperCategories.AsQueryable()
					on item.SuperCategoryId equals sup.Id
				where item.UserId == userId && item.Id == itemId
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
			return await query.SingleOrDefaultAsync();

		}

		public async Task<IEnumerable<PopulatedItem>> GetPopulatedItemsAsync()
		{
			var query =
				from item in _context.Items.AsQueryable()
				join user in _context.Users.AsQueryable()
					on item.UserId equals user.Id
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

		public async Task<IEnumerable<PopulatedItem>> GetPopulatedItemsForUserAsync(Guid userId)
		{
			var query =
				from item in _context.Items.AsQueryable()
				join user in _context.Users.AsQueryable()
					on item.UserId equals user.Id
				join sub in _context.SubCategories.AsQueryable()
					on item.SubCategoryId equals sub.Id
				join sup in _context.SuperCategories.AsQueryable()
					on item.SuperCategoryId equals sup.Id
				where item.UserId == userId
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
