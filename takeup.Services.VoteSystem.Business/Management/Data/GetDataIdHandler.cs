using Microsoft.EntityFrameworkCore;
using takeup.Infrastructure.CQRS;
using takeup.Services.VoteSystem.Domain.Database.DbContexts;
using takeup.Services.VoteSystem.Domain.Viewmodel.Data;

namespace takeup.Services.VoteSystem.Business.Management.Data
{
	public class GetDataIdHandler : CQRSResultHandlerBase<GetDataByMessagesTypes.Request, GetDataByMessagesTypes.Response>
	{
		private readonly VoteSystemReadDbContext _voteSystemReadDbContext;

		public GetDataIdHandler(VoteSystemReadDbContext voteSystemReadDbContext)
		{
			this._voteSystemReadDbContext = voteSystemReadDbContext;
		}

		public override async Task<GetDataByMessagesTypes.Response> Handle(GetDataByMessagesTypes.Request request, CancellationToken cancellationToken)
		{
			var requestMessages = request.Messages.ToHashSet();

			var exists = await _voteSystemReadDbContext.Data
				.Where(d => requestMessages.Contains(d.Message))
				.Select(d => new GetDataByMessagesTypes.DataResponseItem
				{
					DataId = d.DataId,
					Message = d.Message,
				}).ToListAsync();

			var config = await _voteSystemReadDbContext.Configs.FirstAsync(c => c.Id == 1);

			var result = new GetDataByMessagesTypes.Response
			{
				AnswerId = config.AnswerId,
				AnswerAt = config.AnswerAt,
				Items = exists,
			};

			return result;
		}
	}
}
