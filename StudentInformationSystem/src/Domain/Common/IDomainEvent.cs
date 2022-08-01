namespace StudentInformationSystem.Domain.Common
{
    public interface IDomainEvent
    {
        public bool IsPublished { get; set; }
        public DateTimeOffset DateOccurred { get; }
    }
}