using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using StudentInformationSystem.Application.Common.Interfaces;
using StudentInformationSystem.Application.Common.Interfaces.Repositories;
using StudentInformationSystem.Application.Common.Mappings;
using StudentInformationSystem.Application.Common.Models;
using StudentInformationSystem.Domain.Entities;

namespace StudentInformationSystem.Application.Students.Queries.GetStudentsWithPagination;

public class GetStudentsWithPaginationQuery : IRequest<PaginatedList<StudentBriefDto>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}

public class GetStudentsWithPaginationQueryHandler : IRequestHandler<GetStudentsWithPaginationQuery, PaginatedList<StudentBriefDto>>
{
    private readonly IMapper _mapper;
    private readonly IStudentRepository _studentRepository;

    public GetStudentsWithPaginationQueryHandler(IStudentRepository studentRepository, IMapper mapper)
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
    }

    public async Task<PaginatedList<StudentBriefDto>> Handle(GetStudentsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var result = await _studentRepository.GetStudents(request.PageNumber, request.PageSize, cancellationToken);

        var pagedList = new PaginatedList<StudentBriefDto>(
            _mapper.Map<List<Student>, List<StudentBriefDto>>(result.Items), 
            result.TotalCount, 
            result.PageNumber, 
            request.PageSize);

        return pagedList;
    }
}
