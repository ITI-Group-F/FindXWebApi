using FindX.WebApi.Repositories;
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
			builder.Services.AddSingleton<IPopulatorRepository, PopulatorRepository>();
			builder.Services.AddSingleton<ISubCategoryRepository, SubCategoryRepository>();
			builder.Services.AddScoped<IAuthenticate, Authenticate>();
		}
	}
}
