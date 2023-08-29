using Automate.Domain.DomainEvents;
using MediatR;

namespace Automate.Application.Events.Owner
{
    internal sealed class OwnerCreatedDomainEventHandler :
        INotificationHandler<OwnerCreatedDomainEvent>
    {
        public async Task Handle(OwnerCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            //do logic based on event.
            throw new NotImplementedException();
        }
    }
}
