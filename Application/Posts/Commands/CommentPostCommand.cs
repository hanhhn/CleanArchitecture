using Coffee.Domain.Exceptions;
using Coffee.Domain.Interfaces;

namespace Application.Posts.Commands;

public class CommentPostCommand : ICommand
{
    public string PostId { get; set; }
    public string Owner { get; set; }
    public string Message { get; set; }
}

public class CommentPostCommandValidator : AbstractValidator<CommentPostCommand>
{
    public CommentPostCommandValidator()
    {
        RuleFor(v => v.PostId)
            .MaximumLength(36)
            .NotNull()
            .NotEmpty();

        RuleFor(v => v.Owner)
            .MaximumLength(36)
            .NotNull()
            .NotEmpty();

        RuleFor(v => v.Message)
            .MaximumLength(150)
            .NotNull()
            .NotEmpty();
    }
}

public class CommentPostCommandHandler : IRequestHandler<CommentPostCommand>
{
    private readonly IUnitOfWork _context;
    private readonly IPostRepository _postRepository;

    public CommentPostCommandHandler(IUnitOfWork context, IPostRepository postRepository)
    {
        _context = context;
        _postRepository = postRepository;
    }

    public async Task Handle(CommentPostCommand request, CancellationToken cancellationToken)
    {
        var post = _postRepository.FindBy(x => x.Id == request.PostId && !x.IsDeleted).SingleOrDefault();

        if (post == null) throw new RecordNotFoundException();

        post.Comment(request.Owner, request.Message, Guid.NewGuid().ToString());

        await _context.SaveChangesAsync();
    }
}