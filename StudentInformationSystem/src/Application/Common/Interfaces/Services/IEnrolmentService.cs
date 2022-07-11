using StudentInformationSystem.Application.Common.Models;
using StudentInformationSystem.Application.Enrolments;
using StudentInformationSystem.Application.Enrolments.Dtos;
using StudentInformationSystem.Application.Enrolments.Queries.GetEnrolmentsWithPagination;

namespace StudentInformationSystem.Application.Common.Interfaces.Services;

public interface IEnrolmentService
{
    Task<EnrolmentDto> GetEnrolmentById(Guid enrolmentId, CancellationToken cancellationToken = default);
    Task<PaginatedList<EnrolmentBriefDto>> GetEnrolmentsByPagination(int pageNumber, int pageSize, EnrolmentFilter filter, CancellationToken cancellationToken = default);
}
