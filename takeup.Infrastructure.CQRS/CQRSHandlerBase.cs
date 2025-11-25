using MediatR;

namespace takeup.Infrastructure.CQRS
{
	public abstract class CQRSHandlerBase<T> : IRequestHandler<T> where T : CQRSCommandBase
	{
		public abstract Task Handle(T request, CancellationToken cancellationToken);
	}
}
