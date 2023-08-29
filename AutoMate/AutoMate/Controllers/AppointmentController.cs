using Automate.Application.Commands.Appointment;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AppointmentController(IMediator mediator)
        {
            _mediator=mediator;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> PostAsync([FromBody] CreateAppointmentCommand createAppointmentCommand)
        {
            await _mediator.Send(createAppointmentCommand);
            return Ok();
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> PutAsync([FromBody] UpdateAppointmentCommand updateAppointmentCommand)
        {
            await _mediator.Send(updateAppointmentCommand);
            return Ok();
        }
    }
}
