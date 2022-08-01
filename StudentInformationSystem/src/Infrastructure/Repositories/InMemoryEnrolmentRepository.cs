using StudentInformationSystem.Application.Common.Interfaces;
using StudentInformationSystem.Application.Common.Interfaces.Repositories;
using StudentInformationSystem.Application.Common.Models;
using StudentInformationSystem.Application.Enrolments;
using StudentInformationSystem.Domain.Common;
using StudentInformationSystem.Domain.Entities;
using StudentInformationSystem.Domain.Events;

namespace StudentInformationSystem.Infrastructure.Repositories;

public class InMemoryEnrolmentRepository : IEnrolmentRepository
{
    public List<Enrolment> _enrolments = new();
    private readonly IDomainEventService _domainEventService;

    public InMemoryEnrolmentRepository(IDomainEventService domainEventService)
    {
        _domainEventService = domainEventService;
    }

    public async Task<Guid> AddEnrolment(Enrolment enrolment, CancellationToken cancellationToken)
    {
        enrolment.EnrolmentId = enrolment.EnrolmentId == Guid.Empty ? Guid.NewGuid() : enrolment.EnrolmentId;
        enrolment.Created = DateTime.UtcNow;
        enrolment.LastModified = DateTime.UtcNow;

        _enrolments.Add(enrolment);

        enrolment.DomainEvents.Add(new StudentEnrolledEvent(enrolment.StudentId, enrolment.CourseId, enrolment.EnrolmentId));

        await DispatchEvents(enrolment.DomainEvents.ToArray());

        return enrolment.EnrolmentId;
    }

    public async Task<Enrolment> GetEnrolmentById(Guid enrolmentId, CancellationToken cancellationToken)
    {
        return await Task.Run(() => _enrolments.SingleOrDefault(x => x.EnrolmentId == enrolmentId));
    }

    public async Task<PaginatedList<Enrolment>> GetEnrolments(int pageNumber, int pageSize, EnrolmentFilter enrolmentFilters, CancellationToken cancellationToken)
    {
        return await Task.Run(() =>
        {
            var records = _enrolments;
            var count = records.Count;

            return new PaginatedList<Enrolment>(records, count, pageNumber, pageSize);
        });
    }

    public async Task<bool> DoesEnrolmentExist(Guid studentId, Guid courseId, CancellationToken cancellationToken)
    {
        return await Task.Run(() =>
        {
            return _enrolments.Any(x => x.StudentId == studentId && x.CourseId == courseId);
        });
    }

    public async Task DeleteEnrolment(Enrolment enrolmentToDelete, CancellationToken cancellationToken)
    {
        _enrolments.Remove(enrolmentToDelete);
        await DispatchEvents(enrolmentToDelete.DomainEvents.ToArray());
    }

    public async Task<Enrolment> GetEnrolmentByKeyIds(Guid studentId, Guid courseId, CancellationToken cancellationToken = default)
    {
        return await Task.Run(() => _enrolments.SingleOrDefault(x => x.StudentId == studentId && x.CourseId == courseId));
    }

    private async Task DispatchEvents(DomainEvent[] events)
    {
        foreach (var @event in events.Where(x => x.IsPublished == false))
        {
            @event.IsPublished = true;
            await _domainEventService.Publish(@event);
        }
    }
}
