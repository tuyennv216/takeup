using Microsoft.EntityFrameworkCore;
using takeup.Core.Share;
using takeup.Infrastructure.CQRS;
using takeup.Services.VoteSystem.Domain.Database.DbContexts;
using takeup.Services.VoteSystem.Domain.Datatype.ModelContexts;
using takeup.Services.VoteSystem.Domain.Viewmodel.Data;

namespace takeup.Services.VoteSystem.Business.Management.Data
{
	public class AddDataHandler : CQRSResultHandlerBase<AddDataTypes.Request, AddDataTypes.Response>
	{
		private readonly VoteSystemReadDbContext _voteSystemReadDbContext;
		private readonly VoteContext _voteContext;

		public AddDataHandler(VoteSystemReadDbContext voteSystemReadDbContext, VoteContext voteContext)
		{
			this._voteSystemReadDbContext = voteSystemReadDbContext;
			this._voteContext = voteContext;
		}

		public override async Task<AddDataTypes.Response> Handle(AddDataTypes.Request request, CancellationToken cancellationToken)
		{
			var requestMessages = request.Data.Select(x => x.Message).ToHashSet();

			var existsMessage = await _voteSystemReadDbContext.Data
				.Where(d => requestMessages.Contains(d.Message))
				.Select(t => t.Message).ToHashSetAsync();

			requestMessages.ExceptWith(existsMessage);

			var newsItems = requestMessages.Select(m => new Domain.Database.Entities.Data
			{
				Message = m,
			}).ToList();

			foreach (var item in newsItems)
			{
				_voteContext.BatchQueue.Data_Add.Enqueue(item);
			}

			var resultItems = newsItems.Select(d => new AddDataTypes.DataResponseItem
			{
				DataId = d.DataId,
				Message = d.Message,
			}).ToList();

			var result = new AddDataTypes.Response
			{
				AnswerId = SharedVariables.CommitDatabaseJob_AnswerId,
				AnswerAt = SharedVariables.CommitDatabaseJob_NextAnswerTime,
				Items = resultItems,
			};

			return result;
		}
	}
}
