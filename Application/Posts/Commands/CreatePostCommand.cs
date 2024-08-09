using Coffee.Domain.Interfaces;
using Domain.Entities.PostAggregate;

namespace Application.Posts.Commands;

public class CreatePostCommand : ICommand<Post>
{
    public string Title { get; set; }
    public string Image { get; set; }
    public string Description { get; set; }
    public string Content { get; set; }
}

public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
{
    public CreatePostCommandValidator()
    {
        RuleFor(v => v.Title)
            .MaximumLength(150)
            .NotNull()
            .NotEmpty();

        RuleFor(v => v.Image)
            .MaximumLength(200)
            .NotNull()
            .NotEmpty();

        RuleFor(v => v.Description)
            .MaximumLength(300)
            .NotNull()
            .NotEmpty();

        RuleFor(v => v.Content)
           .MaximumLength(1000)
           .NotNull()
           .NotEmpty();
    }
}


public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, Post>
{
    private readonly IUnitOfWork _context;
    private readonly IPostRepository _postRepository;

    public CreatePostCommandHandler(IUnitOfWork context, IPostRepository postRepository)
    {
        _context = context;
        _postRepository = postRepository;
    }

    public async Task<Post> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var created = _postRepository.Add(new()
        {
            Title = request.Title,
            Image = request.Image,
            Description = request.Description,
            Content = request.Content
        });

        await _context.SaveChangesAsync();
        return created;
    }
}