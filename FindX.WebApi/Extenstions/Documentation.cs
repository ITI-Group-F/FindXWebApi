using Microsoft.OpenApi.Models;

namespace FindX.WebApi.Extenstions
{
	public static class Documentation
	{
		public static void AddSwagger(this WebApplicationBuilder builder)
		{
			builder.Services.AddSwaggerGen(option =>
			{
				option.SwaggerDoc("v1", new OpenApiInfo { Title = "FindX API", Version = "v1" });
				option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					In = ParameterLocation.Header,
					Name = "Authorization",
					Type = SecuritySchemeType.Http,
					BearerFormat = "JWT",
					Scheme = "Bearer"
				});
				option.AddSecurityRequirement(new OpenApiSecurityRequirement
		{
				{
						new OpenApiSecurityScheme
						{
								Reference = new OpenApiReference
								{
										Type=ReferenceType.SecurityScheme,
										Id="Bearer"
								}
						},
						new string[]{}
				}
		});
			});

		}
	}
}
