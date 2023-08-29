using Automate.Domain.Entities.Base;
namespace Automate.Domain.DomainEvents;

public sealed record AppointmentCompletedDomainEvent(int AppointmentId, int CarId) :IDomainEvent
{
}
