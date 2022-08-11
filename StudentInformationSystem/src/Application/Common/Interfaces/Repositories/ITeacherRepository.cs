using StudentInformationSystem.Application.Common.Models;
using StudentInformationSystem.Domain.Entities;

namespace StudentInformationSystem.Application.Common.Interfaces.Repositories;

public interface ITeacherRepository
{
    Task<Guid> AddTeacher(Teacher teacher, CancellationToken cancellationToken = default);
    Task<Teacher> GetTeacherById(Guid teacherId, CancellationToken cancellationToken = default);
    Task<PaginatedList<Teacher>> GetTeachers(int pageNumber, int pageSize, CancellationToken cancellationToken = default);
    Task ClearData(CancellationToken cancellationToken = default);
}
