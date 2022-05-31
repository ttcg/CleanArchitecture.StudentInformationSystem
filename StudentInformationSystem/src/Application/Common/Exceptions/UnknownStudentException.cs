namespace StudentInformationSystem.Application.Common.Exceptions;

public class UnknownStudentException : NotFoundException
{
    public UnknownStudentException(Guid studentId) : base($"Unknown student id : {studentId}")
    {
    }
}
