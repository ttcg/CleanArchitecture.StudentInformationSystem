using StudentInformationSystem.Application.Common.Models;
using StudentInformationSystem.Application.Enrolments;
using StudentInformationSystem.Domain.Entities;

namespace StudentInformationSystem.Application.Common.Interfaces.Repositories;

public interface IEnrolmentRepository
{
    Task<PaginatedList<Enrolment>> GetEnrolments(int pageNumber, int pageSize, EnrolmentFilter enrolmentFilter, CancellationToken cancellationToken);

    Task<Guid> AddEnrolment(Enrolment enrolment, CancellationToken cancellationToken);
}
