using MediatR;
using StudentInformationSystem.Application.Common.Exceptions;
using StudentInformationSystem.Application.Common.Interfaces.Repositories;

namespace StudentInformationSystem.Application.Enrolments.Commands.DropoutStudent;

public class DropoutStudentCommand : IRequest
{
    public Guid StudentId { get; set; }
    public Guid CourseId { get; set; }
}

public class DropoutStudentCommandHandler : IRequestHandler<DropoutStudentCommand, Unit>
{
    readonly IEnrolmentRepository _enrolmentRepository;
    public DropoutStudentCommandHandler(
        IEnrolmentRepository enrolmentRepository)
    {
        _enrolmentRepository = enrolmentRepository;
    }

    public async Task<Unit> Handle(DropoutStudentCommand request, CancellationToken cancellationToken)
    {
        await Validate();

        await _enrolmentRepository.DeleteEnrolment(request.StudentId, request.CourseId);

        return Unit.Value;

        async Task Validate()
        {
            if (await _enrolmentRepository.DoesEnrolmentExist(request.StudentId, request.CourseId) == false)
            {
                throw new NotFoundException($"enrolment not found for student id: {request.StudentId} and course id: {request.CourseId}");
            }
        }
    }
}
