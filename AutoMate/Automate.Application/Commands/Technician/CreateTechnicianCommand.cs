using Automate.Application.DataTransferObjects.Technician;
using Automate.Application.Services.Interfaces;
using MediatR;

namespace Automate.Application.Commands.Technician
{
    public sealed record CreateTechnicianCommand(TechnicianDto TechnicianDto) : IRequest;

    public class CreateTechnicianCommandHandler : IRequestHandler<CreateTechnicianCommand>
    {

        private readonly ITechnicianService _technicianService;

        public CreateTechnicianCommandHandler(ITechnicianService technicianService)
        {
            _technicianService=technicianService;
        }

        public async Task Handle(CreateTechnicianCommand request, CancellationToken cancellationToken)
        {
            if (request.TechnicianDto is null)
            {
                throw new ArgumentNullException("Cannot create an Technician, please provide all details.");
            }

            await _technicianService.AddAsync(request.TechnicianDto);
        }
    }
}
