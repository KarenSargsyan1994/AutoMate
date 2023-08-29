using Automate.Domain.Entities.Base;
namespace Automate.Domain.DomainEvents;

public sealed record OwnerCreatedDomainEvent(int OwnerId) : IDomainEvent
{
}
