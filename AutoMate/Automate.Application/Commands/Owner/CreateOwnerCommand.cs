using Automate.Application.DataTransferObjects.Owner;
using Automate.Application.Repositories;
using Automate.Application.Services.Interfaces;
using Automate.Domain.Abstractions;
using MediatR;
namespace Automate.Application.Commands.Owner
{
    public sealed record CreateOwnerCommand : IRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    public class CreateOwnerCommandHandler : IRequestHandler<CreateOwnerCommand>
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateOwnerCommandHandler(IOwnerRepository ownerRepository, IUnitOfWork unitOfWork)
        {
            _ownerRepository=ownerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(CreateOwnerCommand request, CancellationToken cancellationToken)
        {
            if (request is null)
            {
                throw new ArgumentNullException("Cannot create an Owner, please provide all details.");
            }

            var owner = Domain.Entities.Owner.Create(request.Id, request.FirstName,
                request.LastName,
                request.Phone,
                request.Email,
                request.Address,
                request.City,
                request.State,
                request.ZipCode,
                request.DateOfBirth);

            await _ownerRepository.AddAsync(owner);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
