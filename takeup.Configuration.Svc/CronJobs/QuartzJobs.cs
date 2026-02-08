using Quartz;
using takeup.Services.VoteSystem.Business.CronJobs;

namespace takeup.Configuration.Svc.CronJobs
{
	internal static class QuartzJobs
	{
		public static void Config_Jobs(this IServiceCollectionQuartzConfigurator q)
		{
			q.AddJob<CommitDatabaseJob>(j => j
				.WithIdentity("commit-database-job")
				.StoreDurably());

			q.AddJob<AnalystVotesJob>(j => j
				.WithIdentity("analyst-vote-job")
				.StoreDurably());
		}

		public static void Config_Trigger(this IServiceCollectionQuartzConfigurator q)
		{
			q.AddTrigger(t => t
				.WithIdentity("commit-database-trigger")
				.ForJob("commit-database-job")
				.WithCronSchedule("0 0/1 * * * ?")); // 5 phút một lần

			//q.AddTrigger(t => t
			//	.WithIdentity("analyst-vote-trigger")
			//	.ForJob("analyst-vote-job")
			//	.WithCronSchedule("30 0/1 * * * ?")); // 1 phút một lần
		}
	}
}
