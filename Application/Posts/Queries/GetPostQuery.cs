using Coffee.Domain.Interfaces;
using Domain.Entities.PostAggregate;

namespace Application.Posts.Queries;

public class GetPostQuery : IQuery<Post>
{
    public string Id { get; set; }
}

public class GetPostQueryHandler : IRequestHandler<GetPostQuery, Post>
{
    private readonly IPostRepository _postRepository;

    public GetPostQueryHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public Task<Post> Handle(GetPostQuery request, CancellationToken cancellationToken)
    {
        var post = _postRepository.Get(request.Id);
        return Task.FromResult(post);
    }
}