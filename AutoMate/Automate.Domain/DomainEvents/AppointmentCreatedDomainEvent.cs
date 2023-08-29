using Automate.Domain.Entities.Base;
namespace Automate.Domain.DomainEvents;

public sealed record AppointmentCreatedDomainEvent(int AppointmentId, int CarId) : IDomainEvent
{
}
