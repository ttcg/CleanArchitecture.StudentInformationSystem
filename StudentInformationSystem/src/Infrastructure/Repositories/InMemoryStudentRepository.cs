using StudentInformationSystem.Application.Common.Interfaces.Repositories;
using StudentInformationSystem.Application.Common.Models;
using StudentInformationSystem.Domain.Entities;

namespace StudentInformationSystem.Infrastructure.Repositories;

public class InMemoryStudentRepository : IStudentRepository
{
    public List<Student> _students = new();

    public InMemoryStudentRepository()
    {

    }

    public async Task<PaginatedList<Student>> GetStudents(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        return await Task.Run(() =>
        {
            var count = _students.Count;
            var records = _students.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            return new PaginatedList<Student>(records, count, pageNumber, pageSize);
        });
    }

    public async Task<Student> GetStudentById(Guid studentId, CancellationToken cancellationToken)
    {
        return await Task.Run(() => _students.SingleOrDefault(x => x.StudentId == studentId));
    }

    public async Task<Guid> AddStudent(Student student, CancellationToken cancellationToken)
    {
        return await Task.Run(() =>
        {
            student.Created = DateTime.UtcNow;
            student.LastModified = DateTime.UtcNow;            

            _students.Add(student);

            return student.StudentId;
        });
    }
}
