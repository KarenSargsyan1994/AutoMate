﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automate.Application.Commands.Maintenance
{
    public class UpdateMaintenanceCommandValidator : AbstractValidator<UpdateMaintenanceCommand>
    {
        public UpdateMaintenanceCommandValidator()
        {
        }
    }
}
