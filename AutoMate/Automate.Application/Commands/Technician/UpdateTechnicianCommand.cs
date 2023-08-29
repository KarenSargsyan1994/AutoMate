using Automate.Application.DataTransferObjects.Technician;
using Automate.Application.Services.Interfaces;
using MediatR;

namespace Automate.Application.Commands.Technician
{
    public sealed record UpdateTechnicianCommand(TechnicianDto TechnicianDto) : IRequest;

    public class UpdateTechnicianCommandHandler : IRequestHandler<UpdateTechnicianCommand>
    {
        private readonly ITechnicianService _technicianService;

        public UpdateTechnicianCommandHandler(ITechnicianService technicianService)
        {
            _technicianService=technicianService;
        }

        public async Task Handle(UpdateTechnicianCommand request, CancellationToken cancellationToken)
        {
            if (request.TechnicianDto is null)
            {
                throw new ArgumentNullException("Cannot update an Technician, please provide all details.");
            }

            await _technicianService.AddAsync(request.TechnicianDto);
        }
    }
}
