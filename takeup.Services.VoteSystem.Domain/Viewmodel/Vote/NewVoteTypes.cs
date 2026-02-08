using FluentValidation;
using takeup.Infrastructure.CQRS;

namespace takeup.Services.VoteSystem.Domain.Viewmodel.Vote
{
	public class NewVoteTypes
	{
		public class Request : CQRSResultCommandBase<Response>
		{
			public string? IPAddress { get; set; }
			public int TopicId { get; set; }
			public int DataId { get; set; }
		}

		public class Response
		{
			public int AnswerId { get; set; }
			public long AnswerAt { get; set; }
		}

		public class Validator : AbstractValidator<Request>
		{
			public Validator()
			{
				RuleFor(x => x.TopicId)
					.GreaterThan(0).WithMessage("TopicId phải lớn hơn 0.");

				RuleFor(x => x.DataId)
					.GreaterThan(0).WithMessage("DataId phải lớn hơn 0.");
			}
		}
	}
}
