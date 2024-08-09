using Coffee.Domain.Interfaces;

namespace Coffee.Domain.Abtractions
{
    public abstract class BaseMessage : IMessage
    {
        public string MessageId { get; }

        public string MessageName { get; }

        public DateTime CreatedAt { get; }

        public BaseMessage()
        {
            MessageId = Guid.NewGuid().ToString();
            CreatedAt = DateTime.UtcNow;
            MessageName = this.GetType().Name;
        }

        public BaseMessage(string messageName) : this()
        {
            MessageName = messageName;
        }

        public BaseMessage(string messageId, string messageName, DateTime createdAt) : this(messageName)
        {
            MessageId = messageId;
            CreatedAt = createdAt;
        }
    }
}

