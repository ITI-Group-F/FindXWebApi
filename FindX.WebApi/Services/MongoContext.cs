using MongoDB.Driver;
using FindX.WebApi.Model;
using AspNetCore.Identity.MongoDbCore.Infrastructure;

namespace FindX.WebApi.Services
{
	public class MongoContext : IMongoContext
	{
		private readonly string _databaseName;
		public IMongoDatabase Database { get; }
		public IMongoCollection<Item> Items { get; }
		public IMongoCollection<ApplicationUser> Users { get; }
		public IMongoCollection<SuperCategory> SubCategories { get; }
		public IMongoCollection<SuperCategory> SuperCategories { get; }

		public MongoContext(IMongoClient client, IConfiguration configuration)
		{
			_databaseName = configuration["MongoDbSettings:Name"];
			Database = client.GetDatabase(_databaseName);
			Items = Database.GetCollection<Item>("items");
			Users = Database.GetCollection<ApplicationUser>("users");
			SubCategories = Database.GetCollection<SuperCategory>("subCategories");
			SuperCategories = Database.GetCollection<SuperCategory>("superCategories");
		}
	}
}
