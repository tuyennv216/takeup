using Microsoft.EntityFrameworkCore;
using takeup.Core.Share;
using takeup.Infrastructure.CQRS;
using takeup.Services.VoteSystem.Domain.Database.DbContexts;
using takeup.Services.VoteSystem.Domain.Datatype.ModelContexts;
using takeup.Services.VoteSystem.Domain.Viewmodel.Topic;

namespace takeup.Services.VoteSystem.Business.Management.Topic
{
	public class GetTopicsIdHandler : CQRSResultHandlerBase<GetTopicsIdTypes.Request, GetTopicsIdTypes.Response>
	{
		private readonly VoteSystemReadDbContext _voteSystemReadDbContext;
		private readonly VoteContext _voteContext;

		public GetTopicsIdHandler(VoteSystemReadDbContext voteSystemReadDbContext, VoteContext voteContext)
		{
			this._voteSystemReadDbContext = voteSystemReadDbContext;
			this._voteContext = voteContext;
		}

		public override async Task<GetTopicsIdTypes.Response> Handle(GetTopicsIdTypes.Request request, CancellationToken cancellationToken)
		{
			var topicNames = request.Topics.ToHashSet();

			var exists = await _voteSystemReadDbContext.Topics
				.Where(t => topicNames.Contains(t.TopicName))
				.Select(t => new GetTopicsIdTypes.TopicItem
				{
					TopicId = t.TopicId,
					TopicName = t.TopicName,
				}).ToListAsync();

			var result = new GetTopicsIdTypes.Response
			{
				AnswerId = SharedVariables.CommitDatabaseJob_AnswerId,
				AnswerAt = SharedVariables.CommitDatabaseJob_NextAnswerTime,
				Items = exists,
			};

			return result;
		}
	}
}
