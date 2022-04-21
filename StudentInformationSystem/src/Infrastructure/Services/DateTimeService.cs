using StudentInformationSystem.Application.Common.Interfaces;

namespace StudentInformationSystem.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}