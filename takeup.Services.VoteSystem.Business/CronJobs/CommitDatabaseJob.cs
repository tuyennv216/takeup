using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Quartz;
using System.Security.Cryptography;
using takeup.Core.Share;
using takeup.Core.Ultilities.Extensions;
using takeup.Services.VoteSystem.Domain.Database.DbContexts;
using takeup.Services.VoteSystem.Domain.Datatype.ModelContexts;

namespace takeup.Services.VoteSystem.Business.CronJobs
{
	public class CommitDatabaseJob : IJob
	{
		private readonly VoteSystemDbContext _voteSystemDbContext;
		private readonly VoteContext _voteContext;
		private readonly ILogger<CommitDatabaseJob> _logger;

		private static ReaderWriterLockSlim _readerWriterLockSlim = new ReaderWriterLockSlim();

		public CommitDatabaseJob(VoteSystemDbContext voteSystemDbContext, VoteContext voteContext, ILogger<CommitDatabaseJob> logger)
		{
			this._voteSystemDbContext = voteSystemDbContext;
			this._voteContext = voteContext;
			this._logger = logger;
		}

		public async Task Execute(IJobExecutionContext context)
		{
			var runStartTime = DateTime.UtcNow;

			_readerWriterLockSlim.EnterWriteLock();

			try
			{
				using var transaction = await _voteSystemDbContext.Database.BeginTransactionAsync();

				try
				{
					var topicAddItems = _voteContext.BatchQueue.Topic_Add.DequeueAllKeepLast(t => t.TopicId);
					var topicUpdateItems = _voteContext.BatchQueue.Topic_Update.DequeueAll();

					var dataAddItems = _voteContext.BatchQueue.Data_Add.DequeueAllKeepLast(d => d.DataId);
					var dataUpdateItems = _voteContext.BatchQueue.Data_Update.DequeueAll();

					var voteAddItems = _voteContext.BatchQueue.Vote_Add.DequeueAllKeepLast(t => t.IPHash.ToString() + t.TopicId);
					var voteUpdateItems = _voteContext.BatchQueue.Vote_Update.DequeueAll();

					await _voteSystemDbContext.Topics.AddRangeAsync(topicAddItems);
					await _voteSystemDbContext.Data.AddRangeAsync(dataAddItems);
					await _voteSystemDbContext.Votes.AddRangeAsync(voteAddItems);

					_voteSystemDbContext.UpdateRange(topicUpdateItems);
					_voteSystemDbContext.UpdateRange(dataUpdateItems);
					_voteSystemDbContext.UpdateRange(voteUpdateItems);

					await _voteSystemDbContext.SaveChangesAsync();

					var runEndTime = DateTime.UtcNow;
					var runEstimateTime = 2 * (runEndTime - runStartTime);
					var config = await _voteSystemDbContext.Configs.FirstAsync(c => c.Id == 1);
					config.AnswerId = RandomNumberGenerator.GetInt32(Int32.MinValue, Int32.MaxValue);
					config.AnswerAt = runEstimateTime.Ticks;

					await transaction.CommitAsync();

					_logger.LogInformation("Commit database job completed at: {0:yyyy-MM-dd HH:mm:ss}", DateTime.Now);
				}
				catch (Exception ex)
				{
					await transaction.RollbackAsync();
					_logger.LogError(ex, "Error occurred during database commit");
				}
			}
			finally
			{
				_readerWriterLockSlim.ExitWriteLock();
			}
		}
	}
}
