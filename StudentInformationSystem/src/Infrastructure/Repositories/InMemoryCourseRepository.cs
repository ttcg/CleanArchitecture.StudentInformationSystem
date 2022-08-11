using StudentInformationSystem.Application.Common.Interfaces.Repositories;
using StudentInformationSystem.Domain.Entities;

namespace StudentInformationSystem.Infrastructure.Repositories;

public class InMemoryCourseRepository : ICourseRepository
{
    public List<Course> _courses = new();

    public async Task<Course> GetCourseById(Guid courseId, CancellationToken cancellationToken)
    {
        return await Task.Run(() => _courses.SingleOrDefault(x => x.CourseId == courseId));
    }

    public async Task<Guid> AddCourse(Course course, CancellationToken cancellationToken)
    {
        return await Task.Run(() =>
        {
            course.Created = DateTime.UtcNow;
            course.LastModified = DateTime.UtcNow;

            _courses.Add(course);

            return course.CourseId;
        });
    }

    public async Task ClearData(CancellationToken cancellationToken = default)
    {
        await Task.Run(() => _courses.Clear());
    }
}
