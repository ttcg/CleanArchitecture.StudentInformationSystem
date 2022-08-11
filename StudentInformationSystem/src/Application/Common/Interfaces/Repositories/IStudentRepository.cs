using StudentInformationSystem.Application.Common.Models;
using StudentInformationSystem.Domain.Entities;

namespace StudentInformationSystem.Application.Common.Interfaces.Repositories;

public interface IStudentRepository
{
    Task<Guid> AddStudent(Student student, CancellationToken cancellationToken = default);
    Task<Student> GetStudentById(Guid studentId, CancellationToken cancellationToken = default);
    Task<PaginatedList<Student>> GetStudents(int pageNumber, int pageSize, CancellationToken cancellationToken = default);
    Task ClearData(CancellationToken cancellationToken = default);
}
