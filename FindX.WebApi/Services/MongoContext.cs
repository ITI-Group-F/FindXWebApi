using MongoDB.Driver;

namespace FindX.WebApi.Services
{
	public class MongoContext : IMongoContext
	{
		private readonly string _databaseName = "FindX";
		public IMongoDatabase Database { get; }
		public IMongoCollection<Item> Items { get; }

		public MongoContext(IMongoClient client)
		{
			Database = client.GetDatabase(_databaseName);
			Items = Database.GetCollection<Item>("items");
		}
	}
}
