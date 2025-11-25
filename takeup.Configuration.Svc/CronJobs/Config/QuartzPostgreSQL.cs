using Microsoft.Extensions.Hosting;
using Quartz;

namespace takeup.Configuration.Svc.CronJobs.Config
{
	public static class QuartzPostgreSQL
	{
		public static void Config_QuartzPostgreSQL(this IHostApplicationBuilder builder)
		{
			string connectionString = "Host=localhost;Database=quartz;Username=postgres;Password=password";

			builder.Services.AddQuartz(q =>
			{
				q.SchedulerId = "PostgreSQL-Scheduler";
				q.SchedulerName = "PostgreSQL Quartz Scheduler";

				// Sử dụng PostgreSQL JobStore
				q.UsePersistentStore(store =>
				{
					store.UseProperties = true;
					store.UsePostgres(db =>
					{
						db.ConnectionString = connectionString;
						db.TablePrefix = "qrtz_"; // PostgreSQL thường dùng lowercase
					});
					store.UseBinarySerializer();
					store.UseClustering(); // PostgreSQL hỗ trợ clustering tốt
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