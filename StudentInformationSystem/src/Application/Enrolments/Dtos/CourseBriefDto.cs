using StudentInformationSystem.Application.Common.Mappings;
using StudentInformationSystem.Domain.Entities;
using StudentInformationSystem.Domain.Enums;

namespace StudentInformationSystem.Application.Enrolments.Dtos;

public class CourseBriefDto : IMapFrom<Course>
{
    public Guid CourseId { get; set; }
    public string CourseName { get; set; }
}
