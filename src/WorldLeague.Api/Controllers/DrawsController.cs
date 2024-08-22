using MediatR;
using Microsoft.AspNetCore.Mvc;
using WorldLeague.Application.Contracts;
using WorldLeague.Application.Draw.CreateDraw;

namespace WorldLeague.Api.Controllers
{
    [ApiController]
    [Route("api/draws")]
    public class DrawsController : ControllerBase
    {

        private readonly ISender _mediator;

        public DrawsController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CreateDrawResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<IActionResult> Draw([FromBody] CreateDrawCommand command)
        {
            var result = await _mediator.Send(command);

            return Ok(result);
        }

    }
}
