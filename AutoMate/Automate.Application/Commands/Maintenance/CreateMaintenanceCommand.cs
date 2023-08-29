using AutoMapper;
using Automate.Application.DataTransferObjects.Maintenance;
using Automate.Application.Repositories;
using MediatR;

namespace Automate.Application.Commands.Maintenance
{
    public sealed record CreateMaintenanceCommand(MaintenanceDto Maintenance) : IRequest;

    public class CreateMaintenanceCommandHandler : IRequestHandler<CreateMaintenanceCommand>
    {
        private readonly IMaintenanceRepository _maintenanceRepository;
        private readonly IMapper _mapper;

        public CreateMaintenanceCommandHandler(IMaintenanceRepository maintenanceRepository, IMapper mapper)
        {
            _maintenanceRepository=maintenanceRepository;
            _mapper=mapper;
        }

        public async Task Handle(CreateMaintenanceCommand request, CancellationToken cancellationToken)
        {
            if (request.Maintenance is not null)
            {
                var maintenance = _mapper.Map<Domain.Entities.Maintenance>(request.Maintenance);
                await _maintenanceRepository.Add(maintenance);
            }
        }
    }

}
