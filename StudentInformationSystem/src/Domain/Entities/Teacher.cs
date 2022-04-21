namespace StudentInformationSystem.Domain.Entities;

public class Teacher : AuditableEntity
{
    public Guid TeacherId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}
