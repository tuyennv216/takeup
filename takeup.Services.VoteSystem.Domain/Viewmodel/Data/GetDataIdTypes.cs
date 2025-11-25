using FluentValidation;
using takeup.Infrastructure.CQRS;

namespace takeup.Services.VoteSystem.Domain.Viewmodel.Data
{
	public class GetDataIdTypes
	{
		public class Request : CQRSResultCommandBase<Response>
		{
			public required List<DataRequestItem> Data { get; set; }
		}

		public class Response
		{
			public int AnswerId { get; set; }
			public long AnswerAt { get; set; }
			public required List<DataResponseItem> Items { get; set; }
		}

		public class DataRequestItem
		{
			public required string Message { get; set; }
		}

		public class DataResponseItem
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
					.SetValidator(new DataRequestItemValidator());
			}
		}

		public class DataRequestItemValidator : AbstractValidator<DataRequestItem>
		{
			public DataRequestItemValidator()
			{
				RuleFor(x => x.Message)
					.NotEmpty().WithMessage("Nội dung tin nhắn không được để trống.")
					.MaximumLength(100).WithMessage("Nội dung tin nhắn không được vượt quá 100 ký tự.")
					.MinimumLength(1).WithMessage("Nội dung tin nhắn phải có ít nhất 1 ký tự.");
			}
		}
	}
}
