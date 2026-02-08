using Microsoft.EntityFrameworkCore;
using takeup.Core.Share;
using takeup.Infrastructure.CQRS;
using takeup.Services.VoteSystem.Domain.Database.DbContexts;
using takeup.Services.VoteSystem.Domain.Viewmodel.Vote;
using static takeup.Services.VoteSystem.Domain.Viewmodel.Vote.GetVotesTypes;

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

			var items = topicIds.SelectMany(topicId =>
				_voteSystemReadDbContext.Votes
					.Where(v => v.TopicId == topicId)
					.GroupBy(v => new { v.TopicId, v.DataId })
					.Select(g => new TopicVotesItem
					{
						TopicId = g.Key.TopicId,
						Data = g.Select(d => new GetVotesTypes.VoteItem
						{
							DataId = d.DataId,
							NumberOfVotes = g.Count()
						}).ToList()
					})
			).ToList();

			var result = new GetVotesTypes.Response
			{
				AnswerId = config.AnswerId,
				AnswerAt = config.AnswerAt,
				Items = items
			};

			return result;
		}
	}
}
