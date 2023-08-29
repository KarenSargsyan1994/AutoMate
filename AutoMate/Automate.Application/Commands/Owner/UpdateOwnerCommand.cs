using Automate.Application.DataTransferObjects.Owner;
using Automate.Application.Services.Interfaces;
using MediatR;

namespace Automate.Application.Commands.Owner
{
    public sealed record UpdateOwnerCommand(int Id, OwnerDto Owner ) : IRequest;

    public class UpdateOwnerCommandHandler : IRequestHandler<UpdateOwnerCommand>
    {
        private readonly IOwnerService _ownerService;
        public UpdateOwnerCommandHandler(IOwnerService ownerService)
        {
            _ownerService=ownerService;
        }
                 
        public async Task Handle(UpdateOwnerCommand request, CancellationToken cancellationToken)
        {
            if (request.Owner is null)
            {
                throw new ArgumentNullException("Cannot update an Owner, please provide all details.");
            }

            await _ownerService.UpdateAsync(request.Id, request.Owner);
        }
    }   
}
