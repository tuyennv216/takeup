using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Exceptions;
using Serilog.Sinks.FastConsole;

namespace takeup.Configuration.Svc.Services
{
	public static class SerilogConfig
	{
		public static void Config_Serilog(this IHostApplicationBuilder app)
		{
			// Khởi tạo cấu hình cho FastConsole (chế độ JSON)
			var fastConsoleJsonConfig = new FastConsoleSinkOptions { UseJson = true };

			app.Services.AddSerilog((provider, cfg) =>
			{
				cfg.MinimumLevel.Information()
				  .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
				  .Enrich.WithExceptionDetails()
				  .Enrich.FromLogContext();

				if (app.Environment.IsDevelopment())
				{
					// Cấu hình Log dễ đọc cho Development
					cfg.WriteTo.Console(
						restrictedToMinimumLevel: LogEventLevel.Information,
						outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} {Level:u3}] {Message:lj}{NewLine}{Exception}"
					);
				}
				else // Production (hoặc các môi trường khác)
				{
					// Cấu hình JSON cho Production (tối ưu cho công cụ thu thập log)
					cfg.WriteTo.FastConsole(
						fastConsoleJsonConfig,
						restrictedToMinimumLevel: LogEventLevel.Information
					);
				}
			});
		}

		public static void Config_Serilog_Host(this IHostBuilder builder)
		{
			builder.UseSerilog((context, services, configuration) => configuration
				.ReadFrom.Configuration(context.Configuration)
				.ReadFrom.Services(services)
				.Enrich.FromLogContext()
			);
		}
	}
}
