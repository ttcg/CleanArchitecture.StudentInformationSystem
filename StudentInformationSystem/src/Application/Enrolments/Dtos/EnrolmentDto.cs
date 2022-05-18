using StudentInformationSystem.Application.Common.Mappings;
using StudentInformationSystem.Domain.Entities;

namespace StudentInformationSystem.Application.Enrolments.Dtos;

public class EnrolmentDto : IMapFrom<Enrolment>
{
    public Guid EnrolmentId { get; set; }
    public Guid StudentId { get; set; }
    public Guid CourseId { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }

    public StudentBriefDto Student { get; set; }
    public CourseBriefDto Course { get; set; }
}

