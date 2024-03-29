using MongoDB.Driver;
using FindX.WebApi.Models;
using FindX.WebApi.Models.Chat;

namespace FindX.WebApi.Services
{
	public class MongoContext : IMongoContext
	{
		private readonly string _databaseName;
		public IMongoDatabase Database { get; }
		public IMongoCollection<Item> Items { get; }
		public IMongoCollection<Conversation> Conversations { get; }
		public IMongoCollection<ApplicationUser> Users { get; }

		public MongoContext(IMongoClient client, IConfiguration configuration)
		{
			_databaseName = configuration["MongoDbSettings:Name"];
			Database = client.GetDatabase(_databaseName);
			Items = Database.GetCollection<Item>("items");
			Users = Database.GetCollection<ApplicationUser>("users");
			Conversations = Database.GetCollection<Conversation>("conversations");
		}
	}
}
