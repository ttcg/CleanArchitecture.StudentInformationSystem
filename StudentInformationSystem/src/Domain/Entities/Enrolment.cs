namespace StudentInformationSystem.Domain.Entities;

public class Enrolment : AuditableEntity, IHasDomainEvent
{
    public Guid EnrolmentId { get; set; }
    public Guid StudentId { get; set; }
    public Guid CourseId { get; set; }
    public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
}
