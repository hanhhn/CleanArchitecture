namespace Coffee.Infrastructure.Interfaces
{
    public interface IAuditableEntity
    {
        DateTime CreatedAt { get; }
        string CreatedBy { get; }
        DateTime? UpdatedAt { get; }
        string UpdatedBy { get; }
        byte[] Version { get; }
        void SetCreatedBy(string by);
        void SetUpdatedBy(string by);
    }
}

