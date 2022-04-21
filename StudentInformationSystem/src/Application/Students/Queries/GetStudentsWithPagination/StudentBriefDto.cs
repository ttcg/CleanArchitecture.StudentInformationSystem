using StudentInformationSystem.Application.Common.Mappings;
using StudentInformationSystem.Domain.Entities;
using StudentInformationSystem.Domain.Enums;

namespace StudentInformationSystem.Application.Students.Queries.GetStudentsWithPagination;

public class StudentBriefDto : IMapFrom<Student>
{
    public Guid StudentId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Gender Gender { get; set; }
}
