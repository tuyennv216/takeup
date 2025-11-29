using MediatR;
using Microsoft.AspNetCore.Mvc;
using takeup.Services.VoteSystem.Domain.Viewmodel.Vote;

namespace takeup.Services.VoteSystem.Api.Web.Controllers
{
	[ApiController]
	public class VoteController:ControllerBase
	{
		private readonly IMediator _mediator;

		public VoteController(IMediator mediator)
		{
			this._mediator = mediator;
		}

		[HttpPost]
		[Route("/vote/get-votes")]
		public async Task<IActionResult> GetVotes([FromBody] GetVotesTypes.Request request)
		{
			var result = await _mediator.Send(request);
			return Ok(result);
		}

		[HttpPost]
		[Route("/vote/new-vote")]
		public async Task<IActionResult> NewVote([FromBody] NewVoteTypes.Request request)
		{
			var result = await _mediator.Send(request);
			return Ok(result);
		}

	}
}
