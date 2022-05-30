using MongoDB.Driver;
using FindX.WebApi.Model;

namespace FindX.WebApi.Services
{
    public class MongoContext : IMongoContext
    {
        private readonly string _databaseName = "FindX";
        public IMongoDatabase Database { get; }
        public IMongoCollection<Item> Items { get; }
        public IMongoCollection<User> Users { get; }

        public MongoContext(IMongoClient client)
        {
            Database = client.GetDatabase(_databaseName);
            Items = Database.GetCollection<Item>("items");
            Users = Database.GetCollection<User>("items");
        }
    }
}
