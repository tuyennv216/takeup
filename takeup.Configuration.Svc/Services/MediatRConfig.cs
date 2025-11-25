using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using takeup.Services.VoteSystem.Business.Management.Topic;

namespace takeup.Configuration.Svc.Services
{
	public static class MediatRConfig
	{
		public static void Config_MediatR(this IHostApplicationBuilder app)
		{
			var assemblies = new[]
			{
				typeof(AddTopicHandler).Assembly,
			};

			app.Services.AddValidatorsFromAssemblies(assemblies);

			app.Services.AddMediatR(cfg =>
			{
				cfg.RegisterServicesFromAssemblies(assemblies);

				cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
			});
		}
	}

	// Fluent Validation
	public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
		where TRequest : IRequest<TResponse> // Đảm bảo chỉ xử lý Request
	{
		private readonly IEnumerable<IValidator<TRequest>> _validators;

		public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
		{
			// Danh sách này chỉ chứa các Validator được định nghĩa cho TRequest cụ thể
			_validators = validators;
		}

		public async Task<TResponse> Handle(
			TRequest request,
			RequestHandlerDelegate<TResponse> next,
			CancellationToken cancellationToken)
		{
			// 1. Kiểm tra xem có Validator nào được đăng ký cho Request này không
			if (_validators.Any())
			{
				var context = new ValidationContext<TRequest>(request);

				// 2. Chạy tất cả các Validator một cách song song
				var validationResults = await Task.WhenAll(
					_validators.Select(v => v.ValidateAsync(context, cancellationToken))
				);

				// 3. Gom tất cả các lỗi Validation (failures)
				var failures = validationResults
					.Where(r => r.Errors.Any())
					.SelectMany(r => r.Errors)
					.ToList();

				// 4. Nếu có lỗi, ném ngoại lệ
				if (failures.Any())
				{
					// Việc ném ValidationException sẽ chặn Request đi tới Handler và 
					// cho phép tầng API (Controller) bắt lỗi 400 Bad Request.
					throw new ValidationException(failures);
				}
			}

			// 5. Nếu không có lỗi, chuyển Request tới Handler tiếp theo
			return await next();
		}
	}
}
