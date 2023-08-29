using Automate.Application.Commands.Car;
using Automate.Application.Commands.Maintenance;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaintenanceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MaintenanceController(IMediator mediator)
        {
            _mediator=mediator;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> PostAsync([FromBody] CreateMaintenanceCommand createMaintenanceCommand)
        {
            await _mediator.Send(createMaintenanceCommand);
            return Ok();
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> PutAsync([FromBody] UpdateMaintenanceCommand updateMaintenanceCommand)
        {
            await _mediator.Send(updateMaintenanceCommand);
            return Ok();
        }
    }
}
