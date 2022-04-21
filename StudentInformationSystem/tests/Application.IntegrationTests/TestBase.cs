using NUnit.Framework;
using static StudentInformationSystem.Application.IntegrationTests.Testing;

namespace StudentInformationSystem.Application.IntegrationTests
{
    public class TestBase
    {
        [SetUp]
        public async Task TestSetUp()
        {
            await ResetState();
        }
    }
}