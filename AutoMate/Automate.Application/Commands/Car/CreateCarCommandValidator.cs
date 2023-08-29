using FluentValidation;

namespace Automate.Application.Commands.Car
{
    public class CreateCarCommandValidator : AbstractValidator<CreateCarCommand>
    {
        public CreateCarCommandValidator()
        {   
            RuleFor(v => v.Car.Model)
                .MaximumLength(200)
                .NotEmpty();

            RuleFor(v => v.Car.Brand)
                 .MaximumLength(200)
                .NotEmpty();

            RuleFor(v => v.Car.Number)
                .MaximumLength(200)
                .NotEmpty();

            RuleFor(v => v.Car.CurrentMileage)
                .GreaterThan(0)
                .NotEmpty();

            RuleFor(v => v.Car.RegistrationNumber)
              .MaximumLength(70)
              .NotEmpty();
        }
    }
}
