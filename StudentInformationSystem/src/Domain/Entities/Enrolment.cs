namespace StudentInformationSystem.Domain.Entities;

public class Enrolment : AuditableEntity
{
    public Guid EnrolmentId { get; set; }
    public Guid StudentId { get; set; }
    public Guid CourseId { get; set; }
}
