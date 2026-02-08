using Microsoft.EntityFrameworkCore;
using takeup.Core.Share;
using takeup.Infrastructure.CQRS;
using takeup.Services.VoteSystem.Domain.Database.DbContexts;
using takeup.Services.VoteSystem.Domain.Datatype.ModelContexts;
using takeup.Services.VoteSystem.Domain.Viewmodel.Topic;

namespace takeup.Services.VoteSystem.Business.Management.Topic
{
	public class GetTopicsIdHandler : CQRSResultHandlerBase<GetTopicsByNameTypes.Request, GetTopicsByNameTypes.Response>
	{
		private readonly VoteSystemReadDbContext _voteSystemReadDbContext;

		public GetTopicsIdHandler(VoteSystemReadDbContext voteSystemReadDbContext)
		{
			this._voteSystemReadDbContext = voteSystemReadDbContext;
		}

		public override async Task<GetTopicsByNameTypes.Response> Handle(GetTopicsByNameTypes.Request request, CancellationToken cancellationToken)
		{
			var topicNames = request.Topics.ToHashSet();

			var exists = await _voteSystemReadDbContext.Topics
				.Where(t => topicNames.Contains(t.TopicName))
				.Select(t => new GetTopicsByNameTypes.TopicItem
				{
					TopicId = t.TopicId,
					TopicName = t.TopicName,
				}).ToListAsync();

			var config = await _voteSystemReadDbContext.Configs.FirstAsync(c => c.Id == 1);

			var result = new GetTopicsByNameTypes.Response
			{
				AnswerId = config.AnswerId,
				AnswerAt = config.AnswerAt,
				Items = exists,
			};

			return result;
		}
	}
}
