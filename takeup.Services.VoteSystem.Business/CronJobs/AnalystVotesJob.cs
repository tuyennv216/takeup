using Microsoft.Extensions.Logging;
using Quartz;
using takeup.Core.Share;
using takeup.Services.VoteSystem.Domain.Database.DbContexts;
using takeup.Services.VoteSystem.Domain.Datatype.ModelContexts;

namespace takeup.Services.VoteSystem.Business.CronJobs
{
	public class AnalystVotesJob : IJob
	{
		private readonly VoteSystemDbContext _voteSystemDbContext;
		private readonly VoteContext _voteContext;
		private readonly ILogger<AnalystVotesJob> _logger;

		public AnalystVotesJob(VoteSystemDbContext voteSystemDbContext, VoteContext voteContext, ILogger<AnalystVotesJob> logger)
		{
			this._voteSystemDbContext = voteSystemDbContext;
			this._voteContext = voteContext;
			this._logger = logger;
		}

		public async Task Execute(IJobExecutionContext context)
		{
			if (SharedVariables.AnalystVotes_TimeBackoff.ShouldExecute())
			{
				SharedVariables.AnalystVotes = _voteContext.ActiveVotes.GetAllTopicVoteCountsConcurrent();
				_logger.LogInformation("Analyst vote job completed at: {0:yyyy-MM-dd HH:mm:ss}", DateTime.Now);
			}
		}
	}
}
