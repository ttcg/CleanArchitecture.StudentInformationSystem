using FluentValidation;

namespace StudentInformationSystem.Application.Enrolments.Commands.DropoutStudent;

public class DropoutStudentCommandValidator : AbstractValidator<DropoutStudentCommand>
{
    public DropoutStudentCommandValidator()
    {
        RuleFor(v => v.CourseId).NotEmpty();
        RuleFor(v => v.StudentId).NotEmpty();
    }
}
