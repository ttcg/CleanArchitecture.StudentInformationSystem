using MediatR;
using Microsoft.Extensions.Logging;
using StudentInformationSystem.Application.Common.Models;
using StudentInformationSystem.Domain.Events;

namespace StudentInformationSystem.Application.Enrolments.Events;

public class StudentDroppedOutEventHandler : INotificationHandler<DomainEventNotification<StudentDroppedOutEvent>>
{

    private readonly ILogger<StudentDroppedOutEventHandler> _logger;

    public StudentDroppedOutEventHandler(ILogger<StudentDroppedOutEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(DomainEventNotification<StudentDroppedOutEvent> notification, CancellationToken cancellationToken)
    {
        var @event = notification.DomainEvent;
        _logger.LogInformation($"Oh no.  A student {@event.StudentId} has dropped out from class {@event.CourseId}");

        return Task.CompletedTask;
    }
}
