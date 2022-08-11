using StudentInformationSystem.Application.Common.Models;
using StudentInformationSystem.Application.Enrolments;
using StudentInformationSystem.Domain.Entities;

namespace StudentInformationSystem.Application.Common.Interfaces.Repositories;

public interface IEnrolmentRepository
{
    Task<PaginatedList<Enrolment>> GetEnrolments(int pageNumber, int pageSize, EnrolmentFilter enrolmentFilter, CancellationToken cancellationToken = default);
    Task<Guid> AddEnrolment(Enrolment enrolment, CancellationToken cancellationToken = default);
    Task<Enrolment> GetEnrolmentById(Guid enrolmentId, CancellationToken cancellationToken = default);
    Task<bool> DoesEnrolmentExist(Guid studentId, Guid courseId, CancellationToken cancellationToken = default);
    Task<Enrolment> GetEnrolmentByKeyIds(Guid studentId, Guid courseId, CancellationToken cancellationToken = default);
    Task DeleteEnrolment(Enrolment enrolment, CancellationToken cancellationToken = default);
    Task ClearData(CancellationToken cancellationToken = default);
}
