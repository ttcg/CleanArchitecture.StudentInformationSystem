using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInformationSystem.Domain.Entities;

public class Course : AuditableEntity
{
    public Guid CourseId { get; set; }
    public string CourseName { get; set;}
}
