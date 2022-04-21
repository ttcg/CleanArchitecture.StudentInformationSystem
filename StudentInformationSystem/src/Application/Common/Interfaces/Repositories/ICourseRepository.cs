using StudentInformationSystem.Domain.Entities;

namespace StudentInformationSystem.Application.Common.Interfaces.Repositories;

public interface ICourseRepository
{
    Task<Guid> AddCourse(Course course, CancellationToken cancellationToken);
    Task<Course> GetCourseById(Guid courseId, CancellationToken cancellationToken);
}
