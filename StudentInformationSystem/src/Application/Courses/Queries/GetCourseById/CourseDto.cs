using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentInformationSystem.Application.Common.Mappings;
using StudentInformationSystem.Domain.Common;
using StudentInformationSystem.Domain.Entities;

namespace StudentInformationSystem.Application.Courses.Queries.GetCourseById;

public class CourseDto : IMapFrom<Course>, IAmAuditableEntity
{
    public Guid CourseId { get; set; }
    public string CourseName { get; set; }
    public DateTime Created { get; set; }
    public string? CreatedBy { get; set; }
    public DateTime? LastModified { get; set; }
    public string? LastModifiedBy { get; set; }
}
