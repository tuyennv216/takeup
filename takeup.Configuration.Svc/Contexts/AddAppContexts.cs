using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using takeup.Services.VoteSystem.Domain.Datatype.ModelContexts;

namespace takeup.Configuration.Svc.Contexts
{
	public static class AddAppContexts
	{
		public static void Add_AppContexts(this IHostApplicationBuilder app)
		{
			app.Services.AddSingleton<VoteContext>();
		}
	}
}
