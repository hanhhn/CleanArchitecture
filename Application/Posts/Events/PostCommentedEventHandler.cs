using Domain.DomainEvents;
using Microsoft.Extensions.Logging;

namespace Application.Posts.Events;

public class PostCommentedEventHandler : INotificationHandler<PostCommentedEvent>
{
    private readonly ILogger<PostCommentedEventHandler> _logger;

    public PostCommentedEventHandler(ILogger<PostCommentedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(PostCommentedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Domain Event: {DomainEvent}", notification.GetType().Name);

        // send a notification to mobile / web app

        return Task.CompletedTask;
    }
}