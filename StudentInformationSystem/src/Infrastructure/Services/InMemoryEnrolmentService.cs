using AutoMapper;
using StudentInformationSystem.Application.Common.Interfaces.Repositories;
using StudentInformationSystem.Application.Common.Interfaces.Services;
using StudentInformationSystem.Application.Common.Models;
using StudentInformationSystem.Application.Enrolments;
using StudentInformationSystem.Application.Enrolments.Dtos;
using StudentInformationSystem.Application.Enrolments.Queries.GetEnrolmentsWithPagination;
using StudentInformationSystem.Domain.Entities;

namespace StudentInformationSystem.Infrastructure.Services;

public class InMemoryEnrolmentService : IEnrolmentService
{
    readonly IStudentRepository _studentRepository;
    readonly ITeacherRepository _teacherRepository;
    readonly ICourseRepository _courseRepository;
    readonly IEnrolmentRepository _enrolmentRepository;
    private readonly IMapper _mapper;

    public InMemoryEnrolmentService(
        IMapper mapper,
        IStudentRepository studentRepository,
        ITeacherRepository teacherRepository,
        ICourseRepository courseRepository,
        IEnrolmentRepository enrolmentRepository)
    {
        _mapper = mapper; 
        _studentRepository = studentRepository;
        _teacherRepository = teacherRepository;
        _courseRepository = courseRepository;
        _enrolmentRepository = enrolmentRepository;
    }

    public async Task<EnrolmentDto> GetEnrolmentById(Guid enrolmentId, CancellationToken cancellationToken)
    {
        return await Task.Run(async () =>
        {
            var enrolment = await _enrolmentRepository.GetEnrolmentById(enrolmentId, cancellationToken);
            var dto = _mapper.Map<EnrolmentDto>(enrolment);

            var student = await _studentRepository.GetStudentById(enrolment.StudentId, cancellationToken);
            dto.Student = _mapper.Map<StudentBriefDto>(student);

            var course = await _courseRepository.GetCourseById(enrolment.CourseId, cancellationToken);
            dto.Course = _mapper.Map<CourseBriefDto>(course);

            return dto;
        });
    }

    public async Task<PaginatedList<EnrolmentBriefDto>> GetEnrolmentsByPagination(int pageNumber, int pageSize, EnrolmentFilter filter, CancellationToken cancellationToken)
    {
        return await Task.Run(async () =>
        {
            var result = await _enrolmentRepository.GetEnrolments(pageNumber, pageSize, filter);

            var enrolments = new List<EnrolmentBriefDto>();

            foreach(var row in result.Items)
            {
                var enrolment = _mapper.Map<Enrolment, EnrolmentBriefDto>(row);

                var student = await _studentRepository.GetStudentById(row.StudentId, cancellationToken);
                enrolment.StudentName = student.StudentFullName;

                var course = await _courseRepository.GetCourseById(enrolment.CourseId, cancellationToken);
                enrolment.CourseName = course.CourseName;

                enrolments.Add(enrolment);
            }

            var pagedList = new PaginatedList<EnrolmentBriefDto>(
                enrolments,
                result.TotalCount,
                result.PageNumber,
                pageSize);

            return pagedList;
        });
    }
}
