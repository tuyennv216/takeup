using Microsoft.EntityFrameworkCore;
using takeup.Core.Share;
using takeup.Infrastructure.CQRS;
using takeup.Services.VoteSystem.Domain.Database.DbContexts;
using takeup.Services.VoteSystem.Domain.Datatype.ModelContexts;
using takeup.Services.VoteSystem.Domain.Viewmodel.Vote;
using static takeup.Services.VoteSystem.Domain.Datatype.Models.ActiveVote;

namespace takeup.Services.VoteSystem.Business.Management.Vote
{
	public class NewVoteHandler : CQRSResultHandlerBase<NewVoteTypes.Request, NewVoteTypes.Response>
	{
		private readonly VoteSystemReadDbContext _voteSystemReadDbContext;
		private readonly VoteContext _voteContext;

		public NewVoteHandler(VoteSystemReadDbContext voteSystemReadDbContext, VoteContext voteContext)
		{
			this._voteSystemReadDbContext = voteSystemReadDbContext;
			this._voteContext = voteContext;
		}

		public override async Task<NewVoteTypes.Response> Handle(NewVoteTypes.Request request, CancellationToken cancellationToken)
		{
			var ipHash = Core.Ultilities.Securities.Hashing.GenerateGuidFromString(request.IPAddress);

			var expireTime = DateTime.UtcNow.AddMinutes(10).Ticks;
			foreach (var vote in request.Votes)
			{
				var key = new VoteKey(ipHash, vote.TopicId);
				var value = new VoteValue(vote.DataId, expireTime);

				_voteContext.ActiveVotes.VoteDict.AddOrUpdate(
					key: key,
					addValueFactory: k => value,
					updateValueFactory: (k, existingValue) => value
				);
			}
			
			var result = new NewVoteTypes.Response
			{
				AnswerId = SharedVariables.CommitDatabaseJob_AnswerId,
				AnswerAt = SharedVariables.CommitDatabaseJob_NextAnswerTime,
			};

			return result;
		}
	}
}
