using Coffee.Infrastructure.Interfaces;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace Coffee.Application.Behaviours;


public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest> where TRequest : notnull
{
    private readonly ILogger _logger;
    private readonly IIdentityContext _identityContext;

    public LoggingBehaviour(ILogger<TRequest> logger, IIdentityContext identityContext)
    {
        _logger = logger;
        _identityContext = identityContext;
    }

    public Task Process(TRequest request, CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        string userName = _identityContext.GetUserName();

        _logger.LogInformation("Request: {Name} {@UserName} {@Request}", requestName, userName, request);

        return Task.CompletedTask;
    }
}
