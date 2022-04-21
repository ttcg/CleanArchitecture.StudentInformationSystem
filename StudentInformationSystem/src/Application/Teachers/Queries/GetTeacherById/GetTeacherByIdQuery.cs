using AutoMapper;
using MediatR;
using StudentInformationSystem.Application.Common.Exceptions;
using StudentInformationSystem.Application.Common.Interfaces.Repositories;
using StudentInformationSystem.Application.Teachers.Queries.Dtos;
using StudentInformationSystem.Domain.Entities;

namespace StudentInformationSystem.Application.Teachers.Queries.GetTeacherById;

public class GetTeacherByIdQuery : IRequest<TeacherDto>
{
    public Guid TeacherId { get; set; }
}

public class GetTeacherByIdQueryHandler : IRequestHandler<GetTeacherByIdQuery, TeacherDto>
{
    private readonly IMapper _mapper;
    private readonly ITeacherRepository _teacherRepository;

    public GetTeacherByIdQueryHandler(ITeacherRepository teacherRepository, IMapper mapper)
    {
        _teacherRepository = teacherRepository;
        _mapper = mapper;
    }

    public async Task<TeacherDto> Handle(GetTeacherByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _teacherRepository.GetTeacherById(request.TeacherId, cancellationToken);

        if (result == null)
        {
            throw new NotFoundException(nameof(Teacher), request.TeacherId);
        }

        return _mapper.Map<TeacherDto>(result);
    }
}
