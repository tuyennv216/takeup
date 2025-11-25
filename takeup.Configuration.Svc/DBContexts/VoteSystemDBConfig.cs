using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using takeup.Services.VoteSystem.Domain.Database.DbContexts;

namespace takeup.Configuration.Svc.DBContexts
{
	public static class VoteSystemDBConfig
	{
		public static void Config_DBContext_VoteSystem(this IHostApplicationBuilder app)
		{
			// Đăng ký DbContext
			app.Services.AddDbContext<VoteSystemDbContext>((sp, options) =>
			{
				options.UseSqlite("Data Source=votesystem.db");
			}, ServiceLifetime.Scoped);

			// Đăng ký DbContext cho read operations
			app.Services.AddDbContext<VoteSystemReadDbContext>((sp, options) =>
			{
				options.UseSqlite("Data Source=votesystem.db");
				options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
			}, ServiceLifetime.Scoped);
		}
	}
}
