using FluentValidation;
using takeup.Infrastructure.CQRS;

namespace takeup.Services.VoteSystem.Domain.Viewmodel.Data
{
	public class UpdateDataTypes
	{
		public class Request : CQRSResultCommandBase<Response>
		{
			public required List<DataItem> Data { get; set; }
		}

		public class Response
		{
			public int AnswerId { get; set; }
			public long AnswerAt { get; set; }
		}

		public class DataItem
		{
			public int DataId { get; set; }
			public required string Message { get; set; }
		}

		public class Validator : AbstractValidator<Request>
		{
			public Validator()
			{
				RuleFor(x => x.Data)
					.NotNull().WithMessage("Danh sách dữ liệu không được null.")
					.NotEmpty().WithMessage("Ít nhất một mục dữ liệu phải được cung cấp.");

				RuleForEach(x => x.Data)
					.SetValidator(new DataItemValidator());
			}
		}

		public class DataItemValidator : AbstractValidator<DataItem>
		{
			public DataItemValidator()
			{
				RuleFor(x => x.DataId)
					.GreaterThan(0).WithMessage("DataId phải lớn hơn 0.");

				RuleFor(x => x.Message)
					.NotEmpty().WithMessage("Nội dung tin nhắn không được để trống.")
					.MaximumLength(100).WithMessage("Nội dung tin nhắn không được vượt quá 100 ký tự.")
					.MinimumLength(1).WithMessage("Nội dung tin nhắn phải có ít nhất 1 ký tự.");
			}
		}
	}
}
