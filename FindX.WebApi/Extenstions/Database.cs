using FindX.WebApi.Settings;
using MongoDB.Driver;

namespace FindX.WebApi.Extenstions
{
	public static class Database
	{
		public static void RegisterMongoDb(this WebApplicationBuilder builder)
		{
			var mongoDbSettings = builder.Configuration.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>();
			builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(mongoDbSettings.ConnectionString));
		}
	}
}
