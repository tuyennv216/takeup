using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using takeup.Services.VoteSystem.Domain.Datatype.ModelContexts;

namespace takeup.Configuration.Svc.Services.Projects
{
	public static class VoteSystemInjectConfig
	{
		public static void Config_VoteSystem_Inject(this IHostApplicationBuilder app)
		{
			app.Services.AddScoped<VoteContext, VoteContext>();
		}
	}
}
