namespace StudentInformationSystem.Application.Enrolments;

public class EnrolmentFilter
{
    public Guid? EnrolmentId { get; private set; }
    public Guid? StudentId { get; private set; }
    public Guid? CourseId { get; private set; }

    public static EnrolmentFilter Create(Guid? enrolmentId, Guid? studentId, Guid? courseId)
    {
        return new EnrolmentFilter
        {
            EnrolmentId = enrolmentId,
            StudentId = studentId,
            CourseId = courseId
        };
}
}
