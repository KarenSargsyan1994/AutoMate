using Automate.Application.DataTransferObjects.Appointment;
using Automate.Application.Repositories;
using MediatR;

namespace Automate.Application.Commands.Appointment
{
    public sealed record UpdateAppointmentCommand(AppointmentDto Appointment) : IRequest;

    public class UpdateAppointmentCommandHandler : IRequestHandler<UpdateAppointmentCommand>
    {
        public async Task Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
        {

        }
    }
}
