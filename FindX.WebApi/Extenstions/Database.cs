using FindX.WebApi.Model;
using FindX.WebApi.Settings;
using MongoDB.Driver;

namespace FindX.WebApi.Extenstions
{
	public static class Database
	{
		public static void RegisterMongoDb(this WebApplicationBuilder builder)
		{
			var mongoDbSettings = builder.Configuration
				.GetSection(nameof(MongoDbSettings))
				.Get<MongoDbSettings>();
			builder.Services
				.AddIdentity<ApplicationUser, ApplicationRole>()
				.AddMongoDbStores<ApplicationUser, ApplicationRole, Guid>
			(
				mongoDbSettings.ConnectionString,
				mongoDbSettings.Name
			);
			builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(mongoDbSettings.ConnectionString));
			//builder.Services.AddHealthChecks()
			//	.AddMongoDb(
			//		mongoDbSettings.ConnectionString,
			//		name: "FindX",
			//		timeout: TimeSpan.FromSeconds(5),
			//		tags: new[] { "ready" });
		}
	}
}
