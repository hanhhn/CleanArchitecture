namespace Coffee.Infrastructure.Interfaces
{
    public interface IDeleteEntity
    {
        bool IsDeleted { get; }
        void Delete();
        void UnDelete();
    }
}

