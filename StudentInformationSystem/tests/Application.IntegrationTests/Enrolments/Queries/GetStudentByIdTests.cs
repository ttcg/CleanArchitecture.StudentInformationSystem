using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using StudentInformationSystem.Application.Common.Exceptions;
using StudentInformationSystem.Application.Students.Queries.GetStudentById;
using static StudentInformationSystem.Application.IntegrationTests.Testing;

namespace StudentInformationSystem.Application.IntegrationTests.Enrolments.Queries;
public class GetStudentByIdTests : TestBase
{
    [Test]
    public async Task ShouldReturnCorrectStudent()
    {
        var query = new GetStudentByIdQuery
        {
            StudentId = Guid.Parse("90464B9C-AA9B-F3D5-F732-36CE392DCBC3") // ArsenioGrant
        };

        var student = await SendAsync(query);

        student.Should().NotBeNull();
        student.StudentId.Should().Be(query.StudentId);
        student.FirstName.Should().Be("Arsenio");
        student.LastName.Should().Be("Grant");
    }

    [Test]
    public async Task ShouldThrowNotFoundException()
    {
        var query = new GetStudentByIdQuery
        {
            StudentId = Guid.NewGuid()
        };
        await FluentActions.Invoking(() => SendAsync(query)).Should().ThrowAsync<NotFoundException>();
    }
}
