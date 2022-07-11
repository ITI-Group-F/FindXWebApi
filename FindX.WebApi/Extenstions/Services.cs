using FindX.WebApi.Repositories.IRepository;
using FindX.WebApi.Repositories.Repository;
using FindX.WebApi.Services;

namespace FindX.WebApi.Extenstions
{
	public static class Services
	{
		public static void RegisterServices(this WebApplicationBuilder builder)
		{
			builder.Services.AddSingleton<IMongoContext, MongoContext>();
			builder.Services.AddSingleton<IUserItemsRepository, UserItemsRepository>();
			builder.Services.AddSingleton<ISearchRepository, SearchRepository>();
			builder.Services.AddScoped<IAuthenticateService, AuthenticateService>();
			builder.Services.AddSingleton<IItemsRepository, ItemsRepository>();
			builder.Services.AddSingleton<IConversationRepository, ConversationRepository>();
			builder.Services.AddScoped<IUserRepository, UserRepository>();
		}
	}
}
