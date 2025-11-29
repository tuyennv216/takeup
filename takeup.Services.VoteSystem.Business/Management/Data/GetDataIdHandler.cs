using Microsoft.EntityFrameworkCore;
using takeup.Core.Share;
using takeup.Infrastructure.CQRS;
using takeup.Services.VoteSystem.Domain.Database.DbContexts;
using takeup.Services.VoteSystem.Domain.Datatype.ModelContexts;
using takeup.Services.VoteSystem.Domain.Viewmodel.Data;

namespace takeup.Services.VoteSystem.Business.Management.Data
{
	public class GetDataIdHandler : CQRSResultHandlerBase<GetDataIdTypes.Request, GetDataIdTypes.Response>
	{
		private readonly VoteSystemReadDbContext _voteSystemReadDbContext;

		public GetDataIdHandler(VoteSystemReadDbContext voteSystemReadDbContext)
		{
			this._voteSystemReadDbContext = voteSystemReadDbContext;
		}

		public override async Task<GetDataIdTypes.Response> Handle(GetDataIdTypes.Request request, CancellationToken cancellationToken)
		{
			var requestMessages = request.Data.Select(x => x.Message).ToHashSet();

			var exists = await _voteSystemReadDbContext.Data
				.Where(d => requestMessages.Contains(d.Message))
				.Select(d => new GetDataIdTypes.DataResponseItem
				{
					DataId = d.DataId,
					Message = d.Message,
				}).ToListAsync();

			var result = new GetDataIdTypes.Response
			{
				AnswerId = SharedVariables.CommitDatabaseJob_AnswerId,
				AnswerAt = SharedVariables.CommitDatabaseJob_NextAnswerTime,
				Items = exists,
			};

			return result;
		}
	}
}
