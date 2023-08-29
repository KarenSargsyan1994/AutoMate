using Automate.Application.DataTransferObjects.Maintenance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automate.Application.Commands.Maintenance
{
    public sealed record UpdateMaintenanceCommand(MaintenanceDto Maintenance) : IRequest;

    public class UpdateMaintenanceCommandHandler : IRequestHandler<UpdateMaintenanceCommand>
    {
        public async Task Handle(UpdateMaintenanceCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
