using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using takeup.Services.VoteSystem.Domain.Database.DbContexts;

namespace takeup.Configuration.Svc.DBContexts
{
	public static class VoteSystemDBConfig
	{
		public static void Config_VoteSystem_DBContext(this IHostApplicationBuilder app)
		{
			// Đăng ký DbContext
			app.Services.AddDbContext<VoteSystemDbContext>((sp, options) =>
			{
				options.UseSqlite(app.Configuration.GetConnectionString("VoteSystem"));
			}, ServiceLifetime.Scoped);

			// Đăng ký DbContext cho read operations
			app.Services.AddDbContext<VoteSystemReadDbContext>((sp, options) =>
			{
				options.UseSqlite(app.Configuration.GetConnectionString("VoteSystem"));
				options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
			}, ServiceLifetime.Scoped);
		}
	}
}
