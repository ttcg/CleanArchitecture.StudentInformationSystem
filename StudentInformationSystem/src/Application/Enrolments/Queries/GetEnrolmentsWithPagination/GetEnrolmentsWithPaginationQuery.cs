using MediatR;
using StudentInformationSystem.Application.Common.Interfaces.Services;
using StudentInformationSystem.Application.Common.Models;

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
    private readonly IEnrolmentService _enrolmentService;

    public GetEnrolmentsWithPaginationQueryHandler(IEnrolmentService enrolmentService)
    {
        _enrolmentService = enrolmentService;
    }

    public async Task<PaginatedList<EnrolmentBriefDto>> Handle(GetEnrolmentsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        var filter = EnrolmentFilter.Create(request.EnrolmentId, request.StudentId, request.CourseId);

        var result = await _enrolmentService.GetEnrolmentsByPagination(request.PageNumber, request.PageSize, filter, cancellationToken);

        return result;
    }
}