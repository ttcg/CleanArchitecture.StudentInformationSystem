using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentInformationSystem.Application.Common.Models;
using StudentInformationSystem.Application.Students.Queries.GetStudentById;
using StudentInformationSystem.Application.Students.Queries.GetStudentsWithPagination;

namespace StudentInformationSystem.WebApi.Controllers;

[Authorize]
public class StudentsController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<StudentBriefDto>>> GetStudentsWithPagination([FromQuery] GetStudentsWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpGet("{studentId:guid}")]
    public async Task<ActionResult<StudentDto>> GetStudentById(Guid studentId)
    {
        return await Mediator.Send(new GetStudentByIdQuery { StudentId = studentId });
    }
}
