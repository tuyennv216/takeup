using MediatR;
using Microsoft.AspNetCore.Mvc;
using takeup.Services.VoteSystem.Domain.Viewmodel.Data;

namespace takeup.Services.VoteSystem.Api.Web.Controllers
{
	[ApiController]
	public class DataController : ControllerBase
	{
		private readonly IMediator _mediator;

		public DataController(IMediator mediator)
		{
			this._mediator = mediator;
		}

		[HttpPost]
		[Route("/data/add-data")]
		public async Task<IActionResult> AddData([FromBody] AddDataTypes.Request request)
		{
			var result = await _mediator.Send(request);
			return Ok(result);
		}

		[HttpPost]
		[Route("/data/get-data-id")]
		public async Task<IActionResult> GetDataId([FromBody] GetDataIdTypes.Request request)
		{
			var result = await _mediator.Send(request);
			return Ok(result);
		}

		[HttpPost]
		[Route("/data/get-data-message")]
		public async Task<IActionResult> GetDataMessage([FromBody] GetDataMessageTypes.Request request)
		{
			var result = await _mediator.Send(request);
			return Ok(result);
		}

		[HttpPost]
		[Route("/data/update-data")]
		public async Task<IActionResult> UpdateData([FromBody] UpdateDataTypes.Request request)
		{
			var result = await _mediator.Send(request);
			return Ok(result);
		}

	}
}
