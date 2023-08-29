using Automate.Application.Commands.Car;
using Automate.Application.Commands.Owner;
using Automate.Application.Queries.Car;
using Automate.Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarController(IMediator mediator)
        {
            _mediator=mediator;
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> GetCarAsync([FromBody] GetCarByIdQuery getCarByIdQuery)
        {
            var resp = await _mediator.Send(getCarByIdQuery);

            return Ok(resp);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> PostAsync([FromBody] CreateCarCommand createCarCommand)
        {
            await _mediator.Send(createCarCommand);
            return Ok();
        }

        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> PutAsync([FromBody] UpdateCarCommand updateCarCommand)
        {
            await _mediator.Send(updateCarCommand);
            return Ok();
        }
    }
}
