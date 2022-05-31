namespace StudentInformationSystem.Application.Common.Exceptions;

public class UnknownCourseException : NotFoundException
{
    public UnknownCourseException(Guid courseId) : base($"Unknown course id : {courseId}")
    {
    }
}
