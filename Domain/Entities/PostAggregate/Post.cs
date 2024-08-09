using Domain.DomainEvents;

namespace Domain.Entities.PostAggregate
{
    public class Post : AggregateRoot
	{
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }


        public virtual ICollection<Comment> Comments { get; set; }

        public void Comment(string owner, string message, string correlationId)
        {
            if (Comments == null) Comments = new List<Comment>();

            Comments.Add(new()
            {
                Owner = owner,
                Message = message
            });

            var @event = new PostCommentedEvent(this);
            @event.SetCorrelationId(correlationId);
            AddDomainEvent(@event);
        }
    }
}

