using StudentInformationSystem.Application.Common.Mappings;
using StudentInformationSystem.Domain.Common;
using StudentInformationSystem.Domain.Entities;

namespace StudentInformationSystem.Application.Teachers.Queries.Dtos;

public class TeacherDto : IMapFrom<Teacher>, IAmAuditableEntity
{
    public Guid TeacherId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime Created { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? LastModified { get; set; }
    public string? LastModifiedBy { get; set; }
}
