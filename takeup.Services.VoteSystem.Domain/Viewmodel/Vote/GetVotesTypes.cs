using FluentValidation;
using takeup.Infrastructure.CQRS;

namespace takeup.Services.VoteSystem.Domain.Viewmodel.Vote
{
	public class GetVotesTypes
	{
		public class Request : CQRSResultCommandBase<Response>
		{
			public required List<int> TopicIds { get; set; }
		}

		public class Response
		{
			public int AnswerId { get; set; }
			public long AnswerAt { get; set; }
			public required List<TopicVotesItem> Items { get; set; }
		}

		public class TopicVotesItem
		{
			public int TopicId { get; set; }
			public List<VoteItem> Data { get; set; }
		}

		public class VoteItem
		{
			public int DataId { get; set; }
			public int NumberOfVotes {  get; set; }
		}

		public class Validator : AbstractValidator<Request>
		{
			public Validator()
			{
				RuleFor(x => x.TopicIds)
					.NotNull().WithMessage("Danh sách topic không được null.")
					.NotEmpty().WithMessage("Ít nhất một topic phải được cung cấp.");
			}
		}
	}
}
