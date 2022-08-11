using FluentAssertions;
using NUnit.Framework;
using StudentInformationSystem.Application.Common.Exceptions;
using StudentInformationSystem.Application.Enrolments.Commands.DropoutStudent;
using static StudentInformationSystem.Application.IntegrationTests.Testing;

namespace StudentInformationSystem.Application.IntegrationTests.Enrolments.Commands;
public class DropoutStudentTests : TestBase
{
    [Test]
    public async Task ShouldRequireMinimumFields()
    {
        var command = new DropoutStudentCommand();
        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public async Task ShouldDropEnrolment()
    {
        var command = new DropoutStudentCommand
        {
            CourseId = Guid.Parse("e2acab1c-2013-44a3-9ebf-54b4fe8d101e"), // BscComputing
            StudentId = Guid.Parse("90464B9C-AA9B-F3D5-F732-36CE392DCBC3") // ArsenioGrant
        };

        var existingEnrolment = await EnrolmentRepository.GetEnrolmentByKeyIds(command.StudentId, command.CourseId);

        await SendAsync(command);

        var item = await EnrolmentRepository.GetEnrolmentById(existingEnrolment.EnrolmentId);

        item.Should().BeNull();
    }

    [Test]
    public async Task ShouldThrowExceptionForNonExistingEnrolment()
    {
        var command = new DropoutStudentCommand
        {
            CourseId = Guid.Parse("e2acab1c-2013-44a3-9ebf-54b4fe8d101e"), // BscComputing
            StudentId = Guid.Parse("C122E2FB-4492-373C-C337-6AC4EA081E71") // ChristineMayard
        };

        await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }
}
