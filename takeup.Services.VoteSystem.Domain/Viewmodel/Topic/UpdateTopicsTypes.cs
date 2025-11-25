using FluentValidation;
using takeup.Infrastructure.CQRS;

namespace takeup.Services.VoteSystem.Domain.Viewmodel.Topic
{
	public class UpdateTopicsTypes
	{
		public class Request : CQRSResultCommandBase<Response>
		{
			public required List<TopicItem> Topics { get; set; }
		}

		public class Response
		{
			public int AnswerId { get; set; }
			public long AnswerAt { get; set; }
		}

		public class TopicItem
		{
			public int TopicId { get; set; }
			public required string TopicName { get; set; }
		}

		public class Validator : AbstractValidator<Request>
		{
			public Validator()
			{
				RuleFor(x => x.Topics)
					.NotNull().WithMessage("Danh sách chủ đề không được null.")
					.NotEmpty().WithMessage("Ít nhất một chủ đề phải được cung cấp.");

				RuleForEach(x => x.Topics)
					.SetValidator(new TopicItemValidator());
			}
		}

		public class TopicItemValidator : AbstractValidator<TopicItem>
		{
			public TopicItemValidator()
			{
				RuleFor(x => x.TopicName)
					.NotEmpty().WithMessage("Tên chủ đề không được để trống.")
					.MaximumLength(100).WithMessage("Tên chủ đề không được vượt quá 100 ký tự.");
			}
		}
	}
}
