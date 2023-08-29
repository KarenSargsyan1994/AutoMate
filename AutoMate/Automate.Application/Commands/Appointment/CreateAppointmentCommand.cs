using Automate.Application.DataTransferObjects.Appointment;
using MediatR;

namespace Automate.Application.Commands.Appointment
{
    public sealed record CreateAppointmentCommand(AppointmentDto Appointment) : IRequest;  

    public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand>
    {
        public async Task Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
