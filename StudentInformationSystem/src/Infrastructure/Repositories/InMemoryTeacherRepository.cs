using StudentInformationSystem.Application.Common.Interfaces.Repositories;
using StudentInformationSystem.Application.Common.Models;
using StudentInformationSystem.Domain.Entities;

namespace StudentInformationSystem.Infrastructure.Repositories;

public class InMemoryTeacherRepository : ITeacherRepository
{
    public List<Teacher> _teachers = new();

    public async Task<PaginatedList<Teacher>> GetTeachers(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        return await Task.Run(() =>
        {
            var count = _teachers.Count;
            var records = _teachers.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            return new PaginatedList<Teacher>(records, count, pageNumber, pageSize);
        });
    }

    public async Task<Teacher> GetTeacherById(Guid teacherId, CancellationToken cancellationToken)
    { 
        return await Task.Run(() => _teachers.SingleOrDefault(x => x.TeacherId == teacherId));
    }

    public async Task<Guid> AddTeacher(Teacher teacher, CancellationToken cancellationToken)
    {
        return await Task.Run(() =>
        {
            teacher.Created = DateTime.UtcNow;
            teacher.LastModified = DateTime.UtcNow;            

            _teachers.Add(teacher);

            return teacher.TeacherId;
        });
    }

    public async Task ClearData(CancellationToken cancellationToken = default)
    {
        await Task.Run(() => _teachers.Clear());
    }
}
