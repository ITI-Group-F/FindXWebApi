using MongoDB.Driver;

namespace FindX.WebApi.Services
{
	public interface IMongoContext
	{
		public IMongoDatabase Database { get; }
		public IMongoCollection<Item> Items { get; }
		public IMongoCollection<User> Users { get; }
	}
}
