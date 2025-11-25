using MediatR;

namespace takeup.Infrastructure.CQRS
{
	public abstract class CQRSResultCommandBase<TOut> : IRequest<TOut>
	{
		public required Guid UniqueId { get; set; }
	}
}
