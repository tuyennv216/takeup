using Microsoft.Extensions.Hosting;
using takeup.Configuration.Svc.Contexts;
using takeup.Configuration.Svc.CronJobs.Config;
using takeup.Configuration.Svc.DBContexts;

namespace takeup.Core.Scheduler;

public static class Program
{
	public static async Task Main(string[] args)
	{
		DotNetEnv.Env.TraversePath().Load();
		var builder = new HostApplicationBuilder();

		builder.Config_VoteSystem_DBContext();
		builder.Config_QuartzInMemory();

		builder.Add_AppContexts();

		var app = builder.Build();
		await app.RunAsync();
	}
}