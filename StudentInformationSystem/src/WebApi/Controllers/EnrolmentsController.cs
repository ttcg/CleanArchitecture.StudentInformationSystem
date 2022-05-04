using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentInformationSystem.Application.Common.Models;
using StudentInformationSystem.Application.Enrolments.Queries.GetEnrolmentsWithPagination;

namespace StudentInformationSystem.WebApi.Controllers;

[Authorize]
public class EnrolmentsController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<EnrolmentBriefDto>>> GetEnrolmentsByFilter([FromQuery] GetEnrolmentsWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }
}
