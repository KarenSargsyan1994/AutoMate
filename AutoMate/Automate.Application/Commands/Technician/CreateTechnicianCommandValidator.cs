using FluentValidation;

namespace Automate.Application.Commands.Technician
{
    public class CreateTechnicianCommandValidator : AbstractValidator<CreateTechnicianCommand>
    {
        public CreateTechnicianCommandValidator()
        {
        }
    }
}
