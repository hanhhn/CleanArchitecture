using Coffee.Domain.Interfaces;

namespace Coffee.Domain.Abtractions
{
    public abstract class DomainEvent : BaseMessage, IDomainEvent
    {
        public string EventName => base.MessageName;

        public object[] AggregateKeys { get; private set; }

        public string AggregateName { get; private set; }

        public string CorrelationId { get; private set; }


        public DomainEvent() : base()
        {
        }

        public DomainEvent(string eventName) : base(eventName)
        {
        }

        public void SetCorrelationId(string requestId)
        {
            CorrelationId = requestId;
        }
    }
}
