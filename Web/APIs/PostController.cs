using Application.Posts.Commands;
using Application.Posts.Queries;
using Domain.Entities.PostAggregate;

namespace Web.APIs
{
    [ApiVersion(1)]
    [Route("api/v{v:apiVersion}/posts")]
    public class PostController : BaseController
    {
        public PostController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public Task<Post> CreatePost([FromBody] CreatePostCommand  command)
        {
            return _mediator.Send(command);
        }

        [HttpGet("{id}")]
        public Task<Post> GetPost([FromRoute] string id)
        {
            return _mediator.Send(new GetPostQuery { Id = id });
        }

        [HttpPut("{id}/comment")]
        public Task CommentPost([FromRoute] string id, [FromBody] CommentPostCommand command)
        {
            command.PostId = id;
            return _mediator.Send(command);
        }
    }
}

