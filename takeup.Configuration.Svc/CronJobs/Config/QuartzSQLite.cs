using Microsoft.Extensions.Hosting;
using Quartz;

namespace takeup.Configuration.Svc.CronJobs.Config
{
	public static class QuartzSQLite
	{
		public static void Config_QuartzSQLite(this IHostApplicationBuilder builder)
		{
			string sqliteConnectionString = "Data Source=quartz.sqlite;Version=3;";

			builder.Services.AddQuartz(q =>
			{
				q.SchedulerId = "SQLite-Scheduler";
				q.SchedulerName = "SQLite Quartz Scheduler";

				// Sử dụng SQLite JobStore thay vì In-Memory
				q.UsePersistentStore(store =>
				{
					store.UseProperties = true;
					store.UseSQLite(sqlite =>
					{
						sqlite.ConnectionString = sqliteConnectionString;
						sqlite.TablePrefix = "QRTZ_";
					});
					store.UseBinarySerializer();
					// store.UseClustering(); // Bật clustering nếu cần
				});

				q.UseDefaultThreadPool(tp => tp.MaxConcurrency = 10);

				q.Config_Jobs();
				q.Config_Trigger();
			});

			// Đăng ký Quartz hosted service
			builder.Services.AddQuartzHostedService(options =>
			{
				options.WaitForJobsToComplete = true;
			});
		}
	}
}