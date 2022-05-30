namespace FindX.WebApi.Extenstions
{
	public static class ConfigureSeetings
	{
		public static void ConfigureAppSettings(this WebApplicationBuilder builder)
		{
			var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
			builder.Configuration
			.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
			.AddJsonFile($"appsettings.json")
			.AddJsonFile($"appsettings.{env}.json");
		}
	}
}
