using Microsoft.Extensions.Hosting;
using Quartz;

namespace takeup.Configuration.Svc.CronJobs.Config
{
	public static class QuartzInMemory
	{
		public static void Config_QuartzInMemory(this IHostApplicationBuilder builder)
		{
			builder.Services.AddQuartz(q =>
			{
				q.SchedulerId = "InMemory-Scheduler";
				q.SchedulerName = "InMemory Quartz Scheduler";

				// Sử dụng RAMJobStore (mặc định)
				q.UseSimpleTypeLoader();
				q.UseInMemoryStore(); // ← Explicit in-memory
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
