using FluentValidation;

namespace Automate.Application.Commands.Appointment
{
    public class UpdateAppointmentCommandValidator : AbstractValidator<UpdateAppointmentCommand>
    {
        public UpdateAppointmentCommandValidator()
        {
        }
    }
}
