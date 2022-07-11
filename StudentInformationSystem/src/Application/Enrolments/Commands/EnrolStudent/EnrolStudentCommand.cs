using MediatR;
using StudentInformationSystem.Application.Common.Exceptions;
using StudentInformationSystem.Application.Common.Interfaces.Repositories;
using StudentInformationSystem.Domain.Entities;
using StudentInformationSystem.Domain.Exceptions;

namespace StudentInformationSystem.Application.Enrolments.Commands.EnrolStudent;

public class EnrolStudentCommand : IRequest<Guid>
{
    public Guid StudentId { get; set; }
    public Guid CourseId { get; set; }
}

public class EnrolStudentCommandHandler : IRequestHandler<EnrolStudentCommand, Guid>
{
    readonly IEnrolmentRepository _enrolmentRepository;
    readonly IStudentRepository _studentRepository;
    readonly ICourseRepository _courseRepository;
    public EnrolStudentCommandHandler(
        IEnrolmentRepository enrolmentRepository,
        IStudentRepository studentRepository,
        ICourseRepository courseRepository)
    {
        _enrolmentRepository = enrolmentRepository;
        _studentRepository = studentRepository;
        _courseRepository = courseRepository; 
    }

    public async Task<Guid> Handle(EnrolStudentCommand request, CancellationToken cancellationToken)
    {
        await Validate(request, cancellationToken);

        var entity = new Enrolment
        {
            CourseId = request.CourseId,
            StudentId = request.StudentId
        };

        return await _enrolmentRepository.AddEnrolment(entity);

        async Task Validate(EnrolStudentCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetStudentById(request.StudentId, cancellationToken);
            if (student == null)
            {
                throw new UnknownStudentException(request.CourseId);
            }

            var course = await _courseRepository.GetCourseById(request.CourseId, cancellationToken);
            if (course == null)
            {
                throw new UnknownCourseException(request.CourseId);
            }

            if (await _enrolmentRepository.DoesEnrolmentExist(request.StudentId, request.CourseId))
            {
                throw new DuplicateEnrolmentException(request.StudentId, request.CourseId);
            }
        }
    }
}
