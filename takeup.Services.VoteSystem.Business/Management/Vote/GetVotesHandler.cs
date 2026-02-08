using Microsoft.EntityFrameworkCore;
using takeup.Core.Share;
using takeup.Infrastructure.CQRS;
using takeup.Services.VoteSystem.Domain.Database.DbContexts;
using takeup.Services.VoteSystem.Domain.Viewmodel.Vote;

namespace takeup.Services.VoteSystem.Business.Management.Vote
{
	public class GetVotesHandler : CQRSResultHandlerBase<GetVotesTypes.Request, GetVotesTypes.Response>
	{
		private readonly VoteSystemReadDbContext _voteSystemReadDbContext;
		public GetVotesHandler(VoteSystemReadDbContext voteSystemReadDbContext)
		{
			_voteSystemReadDbContext = voteSystemReadDbContext;
		}

		public override async Task<GetVotesTypes.Response> Handle(GetVotesTypes.Request request, CancellationToken cancellationToken)
		{
			var topicIds = request.TopicIds.ToHashSet();

			var config = await _voteSystemReadDbContext.Configs.FirstAsync(c => c.Id == 1);

			var result = new GetVotesTypes.Response
			{
				AnswerId = config.AnswerId,
				AnswerAt = config.AnswerAt,
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
