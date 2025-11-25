using MediatR;

namespace takeup.Infrastructure.CQRS
{
	public abstract class CQRSCommandBase : IRequest
	{
		public required Guid UniqueId { get; set; }
	}
}
