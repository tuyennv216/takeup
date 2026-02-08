using FluentValidation;
using takeup.Infrastructure.CQRS;

namespace takeup.Services.VoteSystem.Domain.Viewmodel.Data
{
	public class GetDataByMessagesTypes
	{
		public class Request : CQRSResultCommandBase<Response>
		{
			public required List<string> Messages { get; set; }
		}

		public class Response
		{
			public int AnswerId { get; set; }
			public long AnswerAt { get; set; }
			public required List<DataResponseItem> Items { get; set; }
		}

		public class DataResponseItem
		{
			public int DataId { get; set; }
			public required string Message { get; set; }
		}`````````

		public class Validator : AbstractValidator<Request>
		{
			public Validator()
			{
				RuleFor(x => x.Messages)
					.NotNull().WithMessage("Danh sách dữ liệu không được null.")
					.NotEmpty().WithMessage("Ít nhất một mục dữ liệu phải được cung cấp.");

			}
		}
	}
}
