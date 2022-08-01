namespace StudentInformationSystem.Domain.Events;

public class StudentEnrolledEvent : DomainEvent, IExternalEvent
{
    public StudentEnrolledEvent()
    {

    }

    public StudentEnrolledEvent(Guid studentId, Guid courseId, Guid enrolmentId)
    {
        StudentId = studentId;
        CourseId = courseId;
        EnrolmentId = enrolmentId;
    }

    public Guid EnrolmentId { get; }
    public Guid StudentId { get; }
    public Guid CourseId { get; }
}
