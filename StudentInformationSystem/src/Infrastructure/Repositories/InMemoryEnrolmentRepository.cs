using StudentInformationSystem.Application.Common.Interfaces.Repositories;
using StudentInformationSystem.Application.Common.Models;
using StudentInformationSystem.Application.Enrolments;
using StudentInformationSystem.Domain.Entities;

namespace StudentInformationSystem.Infrastructure.Repositories;

public class InMemoryEnrolmentRepository : IEnrolmentRepository
{
    public List<Enrolment> _enrolments = new();

    public async Task<Guid> AddEnrolment(Enrolment enrolment, CancellationToken cancellationToken)
    {
        return await Task.Run(() =>
        {
            enrolment.EnrolmentId = enrolment.EnrolmentId == Guid.Empty ? Guid.NewGuid() : enrolment.EnrolmentId;
            enrolment.Created = DateTime.UtcNow;
            enrolment.LastModified = DateTime.UtcNow;

            _enrolments.Add(enrolment);

            return enrolment.EnrolmentId;
        });
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

    public async Task DeleteEnrolment(Guid studentId, Guid courseId, CancellationToken cancellationToken)
    {
        await Task.Run(() =>
        {
            var enrolmentToDelete = _enrolments.Single(x => x.StudentId == studentId && x.CourseId == courseId);

            _enrolments.Remove(enrolmentToDelete);
        });
    }
}
