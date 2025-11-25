using Microsoft.Extensions.Hosting;
using takeup.Configuration.Svc.CronJobs.Config;

namespace takeup.Core.Scheduler;

public static class Program
{
	public static async Task Main(string[] args)
	{
		DotNetEnv.Env.TraversePath().Load();
		var builder = new HostApplicationBuilder();

		builder.Config_QuartzInMemory();

		var app = builder.Build();
		await app.RunAsync();
	}
}