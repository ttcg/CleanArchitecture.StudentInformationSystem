using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentInformationSystem.Application.Courses.Queries.GetCourseById;

namespace StudentInformationSystem.WebApi.Controllers;

[Authorize]
public class CoursesController : ApiControllerBase
{
    [HttpGet("{courseId:guid}")]
    public async Task<ActionResult<CourseDto>> GetCourseById(Guid courseId)
    {
        return await Mediator.Send(new GetCourseByIdQuery { CourseId = courseId });
    }
}
