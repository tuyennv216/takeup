using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace takeup.Configuration.Svc.Services
{
	public static class CorsConfig
	{
		public static void Config_Cors(this IHostApplicationBuilder app)
		{
			app.Services.AddCors(options =>
			{
				options.AddPolicy(
					name: "AllowedOrigins",
					policy =>
					{
						var allowedOrigins = app.Configuration
							.GetSection("CORS:AllowedOrigins")
							.Get<string[]>();

						policy.WithOrigins(allowedOrigins)
							  .AllowAnyMethod()
							  .AllowAnyHeader();
					});

				if (app.Environment.IsDevelopment())
				{
					options.AddPolicy(
						name: "AllowedOrigins",
						policy =>
						{
							policy.WithOrigins("*")
							.AllowAnyHeader()
							.AllowAnyMethod();

							policy.AllowAnyOrigin()
							.AllowAnyHeader()
							.AllowAnyMethod();
						});
				}
			});
		}
	}
}
