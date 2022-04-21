using StudentInformationSystem.Domain.Common;

namespace StudentInformationSystem.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}