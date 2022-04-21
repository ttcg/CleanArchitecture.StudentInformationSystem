namespace StudentInformationSystem.Domain.Common
{
    public interface IAmAuditableEntity
    {
        DateTime Created { get; set; }

        string? CreatedBy { get; set; }

        DateTime? LastModified { get; set; }

        string? LastModifiedBy { get; set; }
    }

    public abstract class AuditableEntity : IAmAuditableEntity
    {
        public DateTime Created { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? LastModified { get; set; }

        public string? LastModifiedBy { get; set; }
    }
}