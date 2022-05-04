using AutoMapper;
using MediatR;
using StudentInformationSystem.Application.Common.Interfaces.Repositories;
using StudentInformationSystem.Application.Common.Models;
using StudentInformationSystem.Domain.Entities;

namespace StudentInformationSystem.Application.Enrolments.Queries.GetEnrolmentsWithPagination;

public class GetEnrolmentsWithPaginationQuery : IRequest<PaginatedList<EnrolmentBriefDto>>
{
    public Guid? EnrolmentId { get; set; }
    public Guid? StudentId { get; set; }
    public Guid? CourseId { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}

public class GetEnrolmentsWithPaginationQueryHandler : IRequestHandler<GetEnrolmentsWithPaginationQuery, PaginatedList<EnrolmentBriefDto>>
{
    private readonly IMapper _mapper;
    private readonly IEnrolmentRepository _enrolmentRepository;

    public GetEnrolmentsWithPaginationQueryHandler(IEnrolmentRepository enrolmentRepository, IMapper mapper)
    {
        _enrolmentRepository = enrolmentRepository;
        _mapper = mapper;
    }

    public async Task<PaginatedList<EnrolmentBriefDto>> Handle(GetEnrolmentsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var filter = EnrolmentFilter.Create(request.EnrolmentId, request.StudentId, request.CourseId);

        var result = await _enrolmentRepository.GetEnrolments(request.PageNumber, request.PageSize, filter, cancellationToken);

        var pagedList = new PaginatedList<EnrolmentBriefDto>(
            _mapper.Map<List<Enrolment>, List<EnrolmentBriefDto>>(result.Items),
            result.TotalCount,
            result.PageNumber,
            request.PageSize);

        return pagedList;
    }
}