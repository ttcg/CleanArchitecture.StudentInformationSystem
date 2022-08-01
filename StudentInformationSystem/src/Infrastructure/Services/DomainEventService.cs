using MediatR;
using Microsoft.Extensions.Logging;
using StudentInformationSystem.Application.Common.Interfaces;
using StudentInformationSystem.Application.Common.Models;
using StudentInformationSystem.Domain.Common;

namespace StudentInformationSystem.Infrastructure.Services
{
    public class DomainEventService : IDomainEventService
    {
        private readonly ILogger<DomainEventService> _logger;
        private readonly IPublisher _mediator;
        private readonly IExternalEventPublisher _externalEventPublisher;

        public DomainEventService(ILogger<DomainEventService> logger, IPublisher mediator, IExternalEventPublisher externalEventPublisher)
        {
            _logger = logger;
            _mediator = mediator;
            _externalEventPublisher = externalEventPublisher;
        }

        public async Task Publish(DomainEvent domainEvent)
        {
            _logger.LogInformation("Publishing domain event. Event - {event}", domainEvent.GetType().Name);
            await _mediator.Publish(GetNotificationCorrespondingToDomainEvent(domainEvent));

            PublishExternalEventIfRequired(domainEvent);
        }

        private INotification GetNotificationCorrespondingToDomainEvent(DomainEvent domainEvent)
        {
            return (INotification)Activator.CreateInstance(
                typeof(DomainEventNotification<>).MakeGenericType(domainEvent.GetType()), domainEvent)!;
        }

        private void PublishExternalEventIfRequired(DomainEvent domainEvent)
        {
            if (domainEvent is IExternalEvent)
            {
                _externalEventPublisher.Publish((IExternalEvent)domainEvent);
            }
        }
    }
}