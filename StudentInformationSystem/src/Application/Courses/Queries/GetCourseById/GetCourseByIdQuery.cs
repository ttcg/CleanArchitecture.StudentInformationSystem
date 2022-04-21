using AutoMapper;
using MediatR;
using StudentInformationSystem.Application.Common.Exceptions;
using StudentInformationSystem.Application.Common.Interfaces.Repositories;
using StudentInformationSystem.Domain.Entities;

namespace StudentInformationSystem.Application.Courses.Queries.GetCourseById;

public class GetCourseByIdQuery : IRequest<CourseDto>
{
    public Guid CourseId { get; set; }
}

public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQuery, CourseDto>
{
    private readonly IMapper _mapper;
    private readonly ICourseRepository _courseRepository;

    public GetCourseByIdQueryHandler(ICourseRepository courseRepository, IMapper mapper)
    {
        _courseRepository = courseRepository;
        _mapper = mapper;
    }

    public async Task<CourseDto> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _courseRepository.GetCourseById(request.CourseId, cancellationToken);

        if (result == null)
        {
            throw new NotFoundException(nameof(Course), request.CourseId);
        }

        return _mapper.Map<CourseDto>(result);
    }
}