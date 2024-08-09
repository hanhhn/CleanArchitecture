namespace Coffee.Domain.Interfaces
{
    public interface IDomainEvent : IMessage
    {
        string AggregateName { get; }

        void SetCorrelationId(string requestId);
    }
}

