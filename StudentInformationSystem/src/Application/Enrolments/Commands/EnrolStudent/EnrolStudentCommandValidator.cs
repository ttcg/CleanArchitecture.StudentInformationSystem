using FluentValidation;

namespace StudentInformationSystem.Application.Enrolments.Commands.EnrolStudent;

public class EnrolStudentCommandValidator : AbstractValidator<EnrolStudentCommand>
{
    public EnrolStudentCommandValidator()
    {
        RuleFor(v => v.CourseId).NotEmpty();
        RuleFor(v => v.StudentId).NotEmpty();
    }
}
