using FindX.WebApi.Models;
using MongoDB.Driver;

namespace FindX.WebApi.Services
{
	public interface IMongoContext
	{
		public IMongoDatabase Database { get; }
		public IMongoCollection<Item> Items { get; }
		public IMongoCollection<ApplicationUser> Users { get; }
		public IMongoCollection<SuperCategory> SuperCategories { get; }
		public IMongoCollection<SubCategory> SubCategories { get; }
	}
}
