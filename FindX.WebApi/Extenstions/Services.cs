using FindX.WebApi.Repositories;
using FindX.WebApi.Services;

namespace FindX.WebApi.Extenstions
{
	public static class Services
	{
		public static void RegisterServices(this WebApplicationBuilder builder)
		{
			builder.Services.AddSingleton<IMongoContext, MongoContext>();
			builder.Services.AddSingleton<IItemRepository, ItemRepository>();
		}
	}
}
