using Microsoft.EntityFrameworkCore;
using takeup.Core.Share;
using takeup.Infrastructure.CQRS;
using takeup.Services.VoteSystem.Domain.Database.DbContexts;
using takeup.Services.VoteSystem.Domain.Datatype.ModelContexts;
using takeup.Services.VoteSystem.Domain.Viewmodel.Topic;

namespace takeup.Services.VoteSystem.Business.Management.Topic
{
	public class AddTopicHandler : CQRSResultHandlerBase<AddTopicsTypes.Request, AddTopicsTypes.Response>
	{
		private readonly VoteSystemReadDbContext _voteSystemReadDbContext;
		private readonly VoteContext _voteContext;

		public AddTopicHandler(VoteSystemReadDbContext voteSystemReadDbContext, VoteContext voteContext)
		{
			this._voteSystemReadDbContext = voteSystemReadDbContext;
			this._voteContext = voteContext;
		}

		public override async Task<AddTopicsTypes.Response> Handle(AddTopicsTypes.Request request, CancellationToken cancellationToken)
		{
			var topicNames = request.Topics.ToHashSet();

			var existsTopic = await _voteSystemReadDbContext.Topics
				.Where(t => topicNames.Contains(t.TopicName))
				.Select(t => new AddTopicsTypes.TopicItem
				{
					TopicId = t.TopicId,
					TopicName = t.TopicName,
				}).ToListAsync();
			var existsName = existsTopic.Select(t => t.TopicName).ToList();

			topicNames.ExceptWith(existsName);

			var newsItems = topicNames.Select(t => new Domain.Database.Entities.Topic
			{
				TopicName = t,
			});

			foreach (var item in newsItems)
			{
				_voteContext.BatchQueue.Topic_Add.Enqueue(item);
			}

			var result = new AddTopicsTypes.Response
			{
				AnswerId = SharedVariables.CommitDatabaseJob_AnswerId,
				AnswerAt = SharedVariables.CommitDatabaseJob_NextAnswerTime,
				Items = existsTopic,
			};

			return result;
		}
	}
}
