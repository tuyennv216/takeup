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
		private readonly VoteSystemReadDbContext _voteSystemReadDbContext;

		public NewVoteHandler(VoteContext voteContext, VoteSystemReadDbContext _voteSystemReadDbContext)
		{
			this._voteContext = voteContext;
			this._voteSystemReadDbContext = _voteSystemReadDbContext;
		}

		public override async Task<NewVoteTypes.Response> Handle(NewVoteTypes.Request request, CancellationToken cancellationToken)
		{
			var config = await _voteSystemReadDbContext.Configs.FirstAsync(c => c.Id == 1);

			if (string.IsNullOrEmpty(request.IPAddress))
			{
				return new NewVoteTypes.Response
				{
					AnswerId = config.AnswerId,
					AnswerAt = config.AnswerAt,
				};
			}

			var ipHash = Core.Ultilities.Securities.Hashing.GenerateGuidFromString(request.IPAddress);

			var existVote = await _voteSystemReadDbContext.Votes
				.Where(v => v.IPHash == ipHash && v.TopicId == request.TopicId)
				.FirstOrDefaultAsync();

			if (existVote != null)
			{
				_voteContext.BatchQueue.Vote_Update.Enqueue(existVote);
			}
			else
			{
				var voteDBItem = new VoteSystem.Domain.Database.Entities.Vote
				{
					IPHash = ipHash,
					TopicId = request.TopicId,
					DataId = request.DataId,
				};

				_voteContext.BatchQueue.Vote_Add.Enqueue(voteDBItem);
			}

			var result = new NewVoteTypes.Response
			{
				AnswerId = config.AnswerId,
				AnswerAt = config.AnswerAt,
			};

			return result;
		}
	}
}
