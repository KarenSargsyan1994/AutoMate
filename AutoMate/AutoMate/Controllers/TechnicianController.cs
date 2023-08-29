using Automate.Application.Commands.Technician;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnicianController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TechnicianController(IMediator mediator)
        {
            _mediator=mediator;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> PostAsync([FromBody] CreateTechnicianCommand createTechnicianCommand)
        {
            await _mediator.Send(createTechnicianCommand);
            return Ok();
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> PutAsync([FromBody] UpdateTechnicianCommand updateTechnicianCommand)
        {
            await _mediator.Send(updateTechnicianCommand);
            return Ok();
        }
    }
}
