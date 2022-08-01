namespace StudentInformationSystem.Domain.Events
{
    public class StudentDroppedOutEvent : DomainEvent
    {
        public StudentDroppedOutEvent(Guid studentId, Guid courseId, Guid enrolmentId)
        {
            StudentId = studentId;
            CourseId = courseId;
            EnrolmentId = enrolmentId;
        }

        public Guid EnrolmentId { get; }
        public Guid StudentId { get; }
        public Guid CourseId { get; }
    }
}