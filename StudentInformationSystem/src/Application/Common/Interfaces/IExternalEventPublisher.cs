using StudentInformationSystem.Domain.Common;

namespace StudentInformationSystem.Application.Common.Interfaces;

public interface IExternalEventPublisher
{
    void Publish(IExternalEvent externalEvent);
}
