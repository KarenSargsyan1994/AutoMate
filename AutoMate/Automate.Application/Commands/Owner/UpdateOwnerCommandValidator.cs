using FluentValidation;

namespace Automate.Application.Commands.Owner
{
    public class UpdateOwnerCommandValidator : AbstractValidator<UpdateOwnerCommand>
    {
        public UpdateOwnerCommandValidator()
        {
            RuleFor(v => v.Owner.Id).NotEmpty();
            RuleFor(v => v.Owner.Phone).NotEmpty();
            RuleFor(v => v.Owner.State).NotEmpty();
            RuleFor(v => v.Owner.Email).NotEmpty();
            RuleFor(v => v.Owner.Address).NotEmpty();
            RuleFor(v => v.Owner.LastName).NotEmpty();
            RuleFor(v => v.Owner.DateOfBirth).NotEmpty();
            RuleFor(v => v.Owner.City).MaximumLength(500).NotEmpty();
            RuleFor(v => v.Owner.ZipCode).MaximumLength(256).NotEmpty();
            RuleFor(v => v.Owner.FirstName).MaximumLength(200).NotEmpty();
        }
    }
}
