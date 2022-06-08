namespace StudentInformationSystem.Domain.Exceptions;

public class DuplicateEnrolmentException : DomainException
{
    public DuplicateEnrolmentException(Guid studentId, Guid courseId) : base($"enrolment already exists between student id: {studentId} and course id: {courseId}")
    {

    }
}
