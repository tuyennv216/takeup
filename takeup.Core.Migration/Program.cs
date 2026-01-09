using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using takeup.Services.VoteSystem.Domain.Database.DbContexts;

namespace takeup.Core.Migration;

public static class Program
{
	public static async Task Main(string[] args)
	{
		DotNetEnv.Env.TraversePath().Load();
		var builder = new HostApplicationBuilder();

		var app = builder.Build();

		// --- Đoạn code chạy Migrate ---
		using (var scope = app.Services.CreateScope())
		{
			var services = scope.ServiceProvider;
			try
			{
				var context = services.GetRequiredService<VoteSystemDbContext>();
				Console.WriteLine("--- Đang kiểm tra và cập nhật Database (Migration) ---");
				await context.Database.MigrateAsync();
				Console.WriteLine("--- Migrate hoàn tất! ---");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Lỗi khi Migrate: {ex.Message}");
			}
		}

		await app.RunAsync();
	}
}