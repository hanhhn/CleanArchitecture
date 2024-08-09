using Domain.Entities.PostAggregate;

namespace Domain.DomainEvents
{
    public class PostCommentedEvent : DomainEvent
    {
		public Post Post { get; private set; }

		public PostCommentedEvent(Post post) : base(nameof(PostCommentedEvent))
		{
			Post = post;
		}
	}
}

