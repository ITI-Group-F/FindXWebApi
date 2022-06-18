using FindX.WebApi.Models;
using FindX.WebApi.Models.Chat;
using MongoDB.Driver;

namespace FindX.WebApi.Services
{
	public interface IMongoContext
	{
		public IMongoDatabase Database { get; }
		public IMongoCollection<Item> Items { get; }
		public IMongoCollection<ApplicationUser> Users { get; }
		public IMongoCollection<Conversation> Conversations { get; }
	}
}
