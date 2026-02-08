using MediatR;
using Microsoft.AspNetCore.Mvc;
using takeup.Services.VoteSystem.Domain.Viewmodel.Topic;

namespace takeup.Services.VoteSystem.Api.Web.Controllers
{
	[ApiController]
	public class TopicController:ControllerBase
	{
		private readonly IMediator _mediator;

		public TopicController(IMediator mediator)
		{
			this._mediator = mediator;
		}

		[HttpPost]
		[Route("/topic/add-topic")]
		public async Task<IActionResult> AddTopic([FromBody] AddTopicsTypes.Request request)
		{
			var result = await _mediator.Send(request);
			return Ok(result);
		}

		[HttpPost]
		[Route("/topic/get-topics-id")]
		public async Task<IActionResult> GetTopicsId([FromBody] GetTopicsByNameTypes.Request request)
		{
			var result = await _mediator.Send(request);
			return Ok(result);
		}

		[HttpPost]
		[Route("/topic/update-topic")]
		public async Task<IActionResult> UpdateTopic([FromBody] UpdateTopicsTypes.Request request)
		{
			var result = await _mediator.Send(request);
			return Ok(result);
		}

	}
}
