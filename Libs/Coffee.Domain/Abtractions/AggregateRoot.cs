using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Coffee.Domain.Interfaces;
using Coffee.Infrastructure.Abtractions;

namespace Coffee.Domain.Abtractions
{
    public abstract class AggregateRoot : BaseEntity<string>, IAggregateRoot
	{
        private LinkedList<IDomainEvent> _domainEvents;

        [NotMapped]
        [JsonIgnore]
        public virtual string AggregateName => GetType().Name;

        [NotMapped]
        [JsonIgnore]
        public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents ?? new LinkedList<IDomainEvent>();

        public void AddDomainEvent(IDomainEvent @event)
        {
            if (_domainEvents == null) _domainEvents = new LinkedList<IDomainEvent>();
            _domainEvents.AddLast(@event);
            //ApplyEvent(@event);
        }
     
        public void ClearDomainEvents()
        {
            if (_domainEvents != null) _domainEvents.Clear();
        }

        public void RemoveDomainEvent(IDomainEvent eventItem)
        {
            if (_domainEvents != null) _domainEvents.Remove(eventItem);
        }

        //private void ApplyEvent(IDomainEvent @event)
        //{
        //    ((dynamic)this).Apply((dynamic)@event);
        //}
    }
}

