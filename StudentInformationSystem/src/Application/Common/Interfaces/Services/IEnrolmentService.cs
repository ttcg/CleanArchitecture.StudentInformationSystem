using StudentInformationSystem.Application.Enrolments.Dtos;

namespace StudentInformationSystem.Application.Common.Interfaces.Services;

public interface IEnrolmentService
{
    Task<EnrolmentDto> GetEnrolmentById(Guid enrolmentId, CancellationToken cancellationToken);
}
