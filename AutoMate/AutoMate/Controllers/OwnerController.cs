using Automate.Application.Commands.Owner;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OwnerController(IMediator mediator)
        {
            _mediator=mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync([FromBody] CreateOwnerCommand createOwnerCommand)
        {
            await _mediator.Send(createOwnerCommand);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] CreateOwnerCommand createOwnerCommand)
        {
            await _mediator.Send(createOwnerCommand);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync([FromBody] UpdateOwnerCommand updateOwnerCommand)
        {
            await _mediator.Send(updateOwnerCommand);
            return Ok();
        }
    }
}
