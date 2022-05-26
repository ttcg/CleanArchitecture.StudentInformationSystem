using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentInformationSystem.Application.Common.Models;
using StudentInformationSystem.Application.Enrolments.Dtos;
using StudentInformationSystem.Application.Enrolments.Queries.GetEnrolmentById;
using StudentInformationSystem.Application.Enrolments.Queries.GetEnrolmentsWithPagination;

namespace StudentInformationSystem.WebApi.Controllers;

[Authorize]
public class EnrolmentsController : ApiControllerBase
{
    [HttpGet]
    [Produces(typeof(PaginatedList<EnrolmentBriefDto>))]
    public async Task<ActionResult<PaginatedList<EnrolmentBriefDto>>> GetEnrolmentsByFilter([FromQuery] GetEnrolmentsWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpGet("{enrolmentId:guid}")]
    public async Task<ActionResult<EnrolmentDto>> GetStudentById(Guid enrolmentId)
    {
        return await Mediator.Send(new GetEnrolmentByIdQuery { EnrolmentId = enrolmentId });
    }
}
