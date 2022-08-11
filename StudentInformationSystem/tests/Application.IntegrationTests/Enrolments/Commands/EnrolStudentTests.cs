using FluentAssertions;
using NUnit.Framework;
using StudentInformationSystem.Application.Common.Exceptions;
using StudentInformationSystem.Application.Enrolments.Commands.EnrolStudent;
using StudentInformationSystem.Domain.Exceptions;
using static StudentInformationSystem.Application.IntegrationTests.Testing;

namespace StudentInformationSystem.Application.IntegrationTests.Enrolments.Commands;
public class EnrolStudentTests : TestBase
{
    [Test]
    public async Task ShouldRequireMinimumFields()
    {
        var command = new EnrolStudentCommand();
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public async Task ShouldCreateEnrolment()
    {
        var command = new EnrolStudentCommand
        {
            CourseId = Guid.Parse("e2acab1c-2013-44a3-9ebf-54b4fe8d101e"), // BscComputing
            StudentId = Guid.Parse("C122E2FB-4492-373C-C337-6AC4EA081E71") // ChristineMayard
        };

        var enrolmentId = await SendAsync(command);

        //var repository = GetEnrolmentRepository();
        var item = await EnrolmentRepository.GetEnrolmentById(enrolmentId);

        item.Should().NotBeNull();
        item.CourseId.Should().Be(command.CourseId);
        item.StudentId.Should().Be(command.StudentId);
        item.Created.Should().BeOnOrBefore(DateTime.Now);
        item.LastModified.Should().BeOnOrBefore(DateTime.Now);
    }

    [Test]
    public async Task ShouldThrowExceptionForDuplicateEnrolment()
    {
        var command = new EnrolStudentCommand
        {
            CourseId = Guid.Parse("e2acab1c-2013-44a3-9ebf-54b4fe8d101e"), // BscComputing
            StudentId = Guid.Parse("90464B9C-AA9B-F3D5-F732-36CE392DCBC3") // ArsenioGrant
        };

        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<DuplicateEnrolmentException>();
    }
}
