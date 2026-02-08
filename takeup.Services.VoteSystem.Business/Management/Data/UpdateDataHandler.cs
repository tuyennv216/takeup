using Microsoft.EntityFrameworkCore;
using takeup.Core.Share;
using takeup.Infrastructure.CQRS;
using takeup.Services.VoteSystem.Domain.Database.DbContexts;
using takeup.Services.VoteSystem.Domain.Datatype.ModelContexts;
using takeup.Services.VoteSystem.Domain.Viewmodel.Data;

namespace takeup.Services.VoteSystem.Business.Management.Data
{
	public class UpdateDataHandler : CQRSResultHandlerBase<UpdateDataTypes.Request, UpdateDataTypes.Response>
	{
		private readonly VoteSystemReadDbContext _voteSystemReadDbContext;
		private readonly VoteContext _voteContext;

		public UpdateDataHandler(VoteSystemReadDbContext voteSystemReadDbContext, VoteContext voteContext)
		{
			this._voteSystemReadDbContext = voteSystemReadDbContext;
			this._voteContext = voteContext;
		}

		public override async Task<UpdateDataTypes.Response> Handle(UpdateDataTypes.Request request, CancellationToken cancellationToken)
		{
			var dataIds = request.Data.Select(t => t.DataId).ToHashSet();

			var existsTopicId = await _voteSystemReadDbContext.Data
				.Where(t => dataIds.Contains(t.DataId))
				.Select(t => t.DataId)
				.ToHashSetAsync();

			var updateData = request.Data
				.Where(t => existsTopicId.Contains(t.DataId))
				.Select(t => new Domain.Database.Entities.Data
			{
				DataId = t.DataId,
				Message = t.Message,
			});

			foreach (var item in updateData)
			{
				_voteContext.BatchQueue.Data_Update.Enqueue(item);
			}

			var config = await _voteSystemReadDbContext.Configs.FirstAsync(c => c.Id == 1);

			var result = new UpdateDataTypes.Response
			{
				AnswerId = config.AnswerId,
				AnswerAt = config.AnswerAt,
			};

			return result;
		}
	}
}
