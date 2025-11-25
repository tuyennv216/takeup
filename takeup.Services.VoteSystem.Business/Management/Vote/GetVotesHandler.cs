using Microsoft.EntityFrameworkCore;
using takeup.Core.Share;
using takeup.Infrastructure.CQRS;
using takeup.Services.VoteSystem.Domain.Database.DbContexts;
using takeup.Services.VoteSystem.Domain.Datatype.ModelContexts;
using takeup.Services.VoteSystem.Domain.Viewmodel.Vote;

namespace takeup.Services.VoteSystem.Business.Management.Vote
{
	public class GetVotesHandler : CQRSResultHandlerBase<GetVotesTypes.Request, GetVotesTypes.Response>
	{
		private readonly VoteSystemReadDbContext _voteSystemReadDbContext;
		private readonly VoteContext _voteContext;

		public GetVotesHandler(VoteSystemReadDbContext voteSystemReadDbContext, VoteContext voteContext)
		{
			this._voteSystemReadDbContext = voteSystemReadDbContext;
			this._voteContext = voteContext;
		}

		public override async Task<GetVotesTypes.Response> Handle(GetVotesTypes.Request request, CancellationToken cancellationToken)
		{
			var topicIds = request.Topics.Select(t => t.TopicId).ToHashSet();

			var result = new GetVotesTypes.Response
			{
				AnswerId = 1,
				AnswerAt = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(),
				Items = topicIds.Select(topicId => new GetVotesTypes.TopicVotesItem
				{
					TopicId = topicId,
					Data = SharedVariables.AnalystVotes.ContainsKey(topicId)
						? SharedVariables.AnalystVotes[topicId]
						: new List<GetVotesTypes.VoteItem>()
				}).ToList()
			};

			return result;
		}
	}
}
