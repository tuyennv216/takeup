using MediatR;

namespace takeup.Infrastructure.CQRS
{
	public abstract class CQRSResultHandlerBase<TIn, TOut> : IRequestHandler<TIn, TOut> where TIn : CQRSResultCommandBase<TOut>
	{
		public abstract Task<TOut> Handle(TIn request, CancellationToken cancellationToken);
	}
}
