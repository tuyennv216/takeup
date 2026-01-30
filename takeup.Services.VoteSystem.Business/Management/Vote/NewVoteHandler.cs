using Microsoft.EntityFrameworkCore;
using takeup.Core.Share;
using takeup.Infrastructure.CQRS;
using takeup.Services.VoteSystem.Domain.Database.DbContexts;
using takeup.Services.VoteSystem.Domain.Datatype.ModelContexts;
using takeup.Services.VoteSystem.Domain.Viewmodel.Vote;

namespace takeup.Services.VoteSystem.Business.Management.Vote
{
	public class NewVoteHandler : CQRSResultHandlerBase<NewVoteTypes.Request, NewVoteTypes.Response>
	{
		private readonly VoteContext _voteContext;
		private readonly VoteSystemReadDbContext _voteSystemDbContext;

		public NewVoteHandler(VoteContext voteContext, VoteSystemReadDbContext voteSystemDbContext)
		{
			this._voteContext = voteContext;
			this._voteSystemDbContext = voteSystemDbContext;
		}

		public override async Task<NewVoteTypes.Response> Handle(NewVoteTypes.Request request, CancellationToken cancellationToken)
		{
			var ipHash = Core.Ultilities.Securities.Hashing.GenerateGuidFromString(request.IPAddress);

			var expireTime = DateTime.UtcNow.AddMinutes(10).Ticks;
			Parallel.ForEach(request.Votes, async voteItem =>
			{
				var existVote = await _voteSystemDbContext.Vote
					.Where(v => v.IPHash == ipHash && v.TopicId == voteItem.TopicId)
					.FirstOrDefaultAsync();

				if (existVote != null)
				{
					existVote.ExpiredAt = expireTime;

					_voteContext.BatchQueue.Vote_Update.Enqueue(existVote);
				}
				else
				{
					var voteDBItem = new VoteSystem.Domain.Database.Entities.Vote
					{
						IPHash = ipHash,
						TopicId = voteItem.TopicId,
						DataId = voteItem.DataId,
						ExpiredAt = expireTime,
					};

					_voteContext.BatchQueue.Vote_Add.Enqueue(voteDBItem);
				}
			});

			var result = new NewVoteTypes.Response
			{
				AnswerId = SharedVariables.CommitDatabaseJob_AnswerId,
				AnswerAt = SharedVariables.CommitDatabaseJob_NextAnswerTime,
			};

			return result;
		}
	}
}
