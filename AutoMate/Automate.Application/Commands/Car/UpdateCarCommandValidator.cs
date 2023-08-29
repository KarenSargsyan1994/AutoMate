using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automate.Application.Commands.Car
{
    public class UpdateCarCommandValidator : AbstractValidator<UpdateCarCommand>
    {
        public UpdateCarCommandValidator()
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
