using Microsoft.EntityFrameworkCore;
using takeup.Core.Share;
using takeup.Infrastructure.CQRS;
using takeup.Services.VoteSystem.Domain.Database.DbContexts;
using takeup.Services.VoteSystem.Domain.Datatype.ModelContexts;
using takeup.Services.VoteSystem.Domain.Viewmodel.Topic;

namespace takeup.Services.VoteSystem.Business.Management.Topic
{
	public class UpdateTopicHandler : CQRSResultHandlerBase<UpdateTopicsTypes.Request, UpdateTopicsTypes.Response>
	{
		private readonly VoteSystemReadDbContext _voteSystemReadDbContext;
		private readonly VoteContext _voteContext;

		public UpdateTopicHandler(VoteSystemReadDbContext voteSystemReadDbContext, VoteContext voteContext)
		{
			this._voteSystemReadDbContext = voteSystemReadDbContext;
			this._voteContext = voteContext;
		}

		public override async Task<UpdateTopicsTypes.Response> Handle(UpdateTopicsTypes.Request request, CancellationToken cancellationToken)
		{
			var topicIds = request.Topics.Select(t => t.TopicId).ToHashSet();

			var existsTopicId = await _voteSystemReadDbContext.Topics
				.Where(t => topicIds.Contains(t.TopicId))
				.Select(t => t.TopicId)
				.ToHashSetAsync();

			var updateTopics = request.Topics
				.Where(t => existsTopicId.Contains(t.TopicId))
				.Select(t => new Domain.Database.Entities.Topic
			{
				TopicId = t.TopicId,
				TopicName = t.TopicName,
			});

			foreach (var item in updateTopics)
			{
				_voteContext.BatchQueue.Topic_Update.Enqueue(item);
			}

			var result = new UpdateTopicsTypes.Response
			{
				AnswerId = SharedVariables.CommitDatabaseJob_AnswerId,
				AnswerAt = SharedVariables.CommitDatabaseJob_NextAnswerTime,
			};

			return result;
		}
	}
}
