using Microsoft.Extensions.Hosting;
using takeup.Configuration.Svc.DBContexts;

namespace takeup.Core.Migration;

public static class Program
{
	public static void Main(string[] args)
	{
		DotNetEnv.Env.TraversePath().Load();
		var builder = new HostApplicationBuilder();

		builder.Config_DBContext_VoteSystem();

		var app = builder.Build();
		app.Run();
	}
}