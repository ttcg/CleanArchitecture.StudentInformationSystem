using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentInformationSystem.Application.Common.Models;
using StudentInformationSystem.Application.Enrolments.Commands.DropoutStudent;
using StudentInformationSystem.Application.Enrolments.Commands.EnrolStudent;
using StudentInformationSystem.Application.Enrolments.Dtos;
using StudentInformationSystem.Application.Enrolments.Queries.GetEnrolmentById;
using StudentInformationSystem.Application.Enrolments.Queries.GetEnrolmentsWithPagination;
using StudentInformationSystem.WebApi.Models;

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
    public async Task<ActionResult<EnrolmentDto>> GetEnrolmentById(Guid enrolmentId)
    {
        return await Mediator.Send(new GetEnrolmentByIdQuery { EnrolmentId = enrolmentId });
    }

    [HttpPost]
    public async Task<CreatedAtActionResult> EnrolStudent(EnrolStudentModel model)
    {
        var command = new EnrolStudentCommand
        {
            CourseId = model.CourseId,
            StudentId = model.StudentId
        };

        var enrolmentId = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetEnrolmentById), new { enrolmentId }, enrolmentId);
    }

    [HttpDelete]
    public async Task<NoContentResult> DropoutStudent(DropoutStudentModel model)
    {
        var command = new DropoutStudentCommand
        {
            CourseId = model.CourseId,
            StudentId = model.StudentId
        };

        var enrolmentId = await Mediator.Send(command);

        return NoContent();
    }
}
