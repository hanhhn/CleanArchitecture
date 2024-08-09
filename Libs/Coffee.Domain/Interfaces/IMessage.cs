using MediatR;

namespace Coffee.Domain.Interfaces
{
    public interface IMessage : INotification
	{
        string MessageId { get; }
        string MessageName { get; }
        DateTime CreatedAt { get; }
    }
}

