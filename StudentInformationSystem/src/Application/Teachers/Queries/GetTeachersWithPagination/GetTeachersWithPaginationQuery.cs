using AutoMapper;
using MediatR;
using StudentInformationSystem.Application.Common.Interfaces.Repositories;
using StudentInformationSystem.Application.Common.Models;
using StudentInformationSystem.Application.Teachers.Queries.Dtos;
using StudentInformationSystem.Domain.Entities;

namespace StudentInformationSystem.Application.Teachers.Queries.GetTeachersWithPagination;

public class GetTeachersWithPaginationQuery : IRequest<PaginatedList<TeacherDto>>
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}

public class GetTeachersWithPaginationQueryHandler : IRequestHandler<GetTeachersWithPaginationQuery, PaginatedList<TeacherDto>>
{
    private readonly IMapper _mapper;
    private readonly ITeacherRepository _teacherRepository;

    public GetTeachersWithPaginationQueryHandler(ITeacherRepository teacherRepository, IMapper mapper)
    {
        _teacherRepository = teacherRepository;
        _mapper = mapper;
    }

    public async Task<PaginatedList<TeacherDto>> Handle(GetTeachersWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var result = await _teacherRepository.GetTeachers(request.PageNumber, request.PageSize, cancellationToken);

        var pagedList = new PaginatedList<TeacherDto>(
            _mapper.Map<List<Teacher>, List<TeacherDto>>(result.Items),
            result.TotalCount,
            result.PageNumber,
            request.PageSize);

        return pagedList;
    }
}
