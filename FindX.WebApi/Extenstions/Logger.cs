using Serilog;
using Serilog.Exceptions;

namespace FindX.WebApi.Extenstions
{
	public static class Logger
	{
		public static void ConfigureSerilog(this WebApplicationBuilder builder)
		{
			Log.Logger = new LoggerConfiguration()
				.Enrich.FromLogContext()
				.Enrich.WithExceptionDetails()
				.WriteTo.Debug()
				.WriteTo.Console()
				.CreateLogger();
		}
	}
}
