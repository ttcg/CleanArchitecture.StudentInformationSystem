using StudentInformationSystem.Application.Common.Mappings;
using StudentInformationSystem.Domain.Common;
using StudentInformationSystem.Domain.Entities;
using StudentInformationSystem.Domain.Enums;

namespace StudentInformationSystem.Application.Students.Queries.GetStudentById;

public class StudentDto : IMapFrom<Student>, IAmAuditableEntity
{
    public Guid StudentId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Gender Gender { get; set; }
    public DateTime Created { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? LastModified { get; set; }
    public string? LastModifiedBy { get; set; }
}
