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
			var config = new FastConsoleSinkOptions { UseJson = true };

			app.Services.AddSerilog((provider, cfg) =>
			{
				cfg.MinimumLevel.Information()
				  // Tự động thêm thông tin exception chi tiết (cần Serilog.Exceptions)
				  .Enrich.WithExceptionDetails()
				  // Tự động lấy TraceId/SpanId từ context
				  .Enrich.FromLogContext()

				  // Cấu hình Sink: Ghi ra Console dưới dạng JSON (Tối ưu cho Fluent Bit)
				  .WriteTo.FastConsole(
					  config,
					  restrictedToMinimumLevel: LogEventLevel.Information
				  );
			});
		}
	}
}
