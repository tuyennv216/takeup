using Microsoft.EntityFrameworkCore;
using takeup.Core.Share;
using takeup.Infrastructure.CQRS;
using takeup.Services.VoteSystem.Domain.Database.DbContexts;
using takeup.Services.VoteSystem.Domain.Datatype.ModelContexts;
using takeup.Services.VoteSystem.Domain.Viewmodel.Data;

namespace takeup.Services.VoteSystem.Business.Management.Data
{
	public class GetDataMessageHandler : CQRSResultHandlerBase<GetDataMessageTypes.Request, GetDataMessageTypes.Response>
	{
		private readonly VoteSystemReadDbContext _voteSystemReadDbContext;

		public GetDataMessageHandler(VoteSystemReadDbContext voteSystemReadDbContext)
		{
			this._voteSystemReadDbContext = voteSystemReadDbContext;
		}

		public override async Task<GetDataMessageTypes.Response> Handle(GetDataMessageTypes.Request request, CancellationToken cancellationToken)
		{
			var requestIds = request.Data.Select(x => x.DataId).ToHashSet();

			var exists = await _voteSystemReadDbContext.Data
				.Where(d => requestIds.Contains(d.DataId))
				.Select(d => new GetDataMessageTypes.DataResponseItem
				{
					DataId = d.DataId,
					Message = d.Message,
				}).ToListAsync();

			var result = new GetDataMessageTypes.Response
			{
				AnswerId = SharedVariables.CommitDatabaseJob_AnswerId,
				AnswerAt = SharedVariables.CommitDatabaseJob_NextAnswerTime,
				Items = exists,
			};

			return result;
		}
	}
}
