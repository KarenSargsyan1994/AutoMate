using Automate.Application.Commands.Owner;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automate.Application.Commands.Maintenance
{
    public class CreateMaintenanceCommandValidator : AbstractValidator<CreateMaintenanceCommand>
    {
        public CreateMaintenanceCommandValidator()
        {
        }
    }
}
