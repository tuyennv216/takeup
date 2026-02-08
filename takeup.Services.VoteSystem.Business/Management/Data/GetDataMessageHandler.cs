using Microsoft.EntityFrameworkCore;
using takeup.Core.Share;
using takeup.Infrastructure.CQRS;
using takeup.Services.VoteSystem.Domain.Database.DbContexts;
using takeup.Services.VoteSystem.Domain.Datatype.ModelContexts;
using takeup.Services.VoteSystem.Domain.Viewmodel.Data;

namespace takeup.Services.VoteSystem.Business.Management.Data
{
	public class GetDataMessageHandler : CQRSResultHandlerBase<GetDataByIdTypes.Request, GetDataByIdTypes.Response>
	{
		private readonly VoteSystemReadDbContext _voteSystemReadDbContext;

		public GetDataMessageHandler(VoteSystemReadDbContext voteSystemReadDbContext)
		{
			this._voteSystemReadDbContext = voteSystemReadDbContext;
		}

		public override async Task<GetDataByIdTypes.Response> Handle(GetDataByIdTypes.Request request, CancellationToken cancellationToken)
		{
			var requestIds = request.DataIds.ToHashSet();

			var exists = await _voteSystemReadDbContext.Data
				.Where(d => requestIds.Contains(d.DataId))
				.Select(d => new GetDataByIdTypes.DataResponseItem
				{
					DataId = d.DataId,
					Message = d.Message,
				}).ToListAsync();

			var config = await _voteSystemReadDbContext.Configs.FirstAsync(c => c.Id == 1);

			var result = new GetDataByIdTypes.Response
			{
				AnswerId = config.AnswerId,
				AnswerAt = config.AnswerAt,
				Items = exists,
			};

			return result;
		}
	}
}
