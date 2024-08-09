using Coffee.Infrastructure.Interfaces;

namespace Coffee.Domain.Interfaces
{
	public interface IAggregateRoot : IEntityRoot
	{
        string AggregateName { get; }

        IReadOnlyCollection<IDomainEvent> DomainEvents { get; }

        void AddDomainEvent(IDomainEvent @event);

        void ClearDomainEvents();

        void RemoveDomainEvent(IDomainEvent eventItem);
    }
}

