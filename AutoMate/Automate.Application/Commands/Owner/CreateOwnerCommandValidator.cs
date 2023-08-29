using FluentValidation;

namespace Automate.Application.Commands.Owner
{
    public class CreateOwnerCommandValidator : AbstractValidator<CreateOwnerCommand>
    {
        public CreateOwnerCommandValidator()
        {
            RuleFor(v => v.Phone).NotEmpty();
            RuleFor(v => v.State).NotEmpty();
            RuleFor(v => v.Email).NotEmpty();
            RuleFor(v => v.Address).NotEmpty();
            RuleFor(v => v.LastName).NotEmpty();
            RuleFor(v => v.DateOfBirth).NotEmpty();
            RuleFor(v => v.City).MaximumLength(500).NotEmpty();
            RuleFor(v => v.ZipCode).MaximumLength(256).NotEmpty();
            RuleFor(v => v.FirstName).MaximumLength(200).NotEmpty();
        }
    }
}
