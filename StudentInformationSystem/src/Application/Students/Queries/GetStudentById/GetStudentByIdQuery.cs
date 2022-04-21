using AutoMapper;
using MediatR;
using StudentInformationSystem.Application.Common.Exceptions;
using StudentInformationSystem.Application.Common.Interfaces.Repositories;
using StudentInformationSystem.Domain.Entities;

namespace StudentInformationSystem.Application.Students.Queries.GetStudentById;

public class GetStudentByIdQuery : IRequest<StudentDto>
{
    public Guid StudentId { get; set; }
}

public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, StudentDto>
{
    private readonly IMapper _mapper;
    private readonly IStudentRepository _studentRepository;

    public GetStudentByIdQueryHandler(IStudentRepository studentRepository, IMapper mapper)
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
    }

    public async Task<StudentDto> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _studentRepository.GetStudentById(request.StudentId, cancellationToken);

        if (result == null)
        {
            throw new NotFoundException(nameof(Student), request.StudentId);
        }

        return _mapper.Map<StudentDto>(result);
    }
}
