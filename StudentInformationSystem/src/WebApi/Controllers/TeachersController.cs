using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentInformationSystem.Application.Common.Models;
using StudentInformationSystem.Application.Teachers.Queries.Dtos;
using StudentInformationSystem.Application.Teachers.Queries.GetTeacherById;
using StudentInformationSystem.Application.Teachers.Queries.GetTeachersWithPagination;

namespace StudentInformationSystem.WebApi.Controllers;

[Authorize]
public class TeachersController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<TeacherDto>>> GetTeachersWithPagination([FromQuery] GetTeachersWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpGet("{teacherId:guid}")]
    public async Task<ActionResult<TeacherDto>> GetTeacherById(Guid teacherId)
    {
        return await Mediator.Send(new GetTeacherByIdQuery { TeacherId = teacherId });
    }
}
