using System.Diagnostics;
using Coffee.Infrastructure.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Coffee.Application.Behaviours;

public class PerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly Stopwatch _timer;
    private readonly ILogger<TRequest> _logger;
    private readonly IIdentityContext _identityContext;

    public PerformanceBehaviour(
        ILogger<TRequest> logger,
        IIdentityContext identityContext)
    {
        _timer = new Stopwatch();

        _logger = logger;
        _identityContext = identityContext;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _timer.Start();

        var response = await next();

        _timer.Stop();

        var elapsedMilliseconds = _timer.ElapsedMilliseconds;

        if (elapsedMilliseconds > 500)
        {
            var requestName = typeof(TRequest).Name;
            var userId = _identityContext.GetUID() ?? "Unknow";
            var userName = string.Empty;

            if (!string.IsNullOrEmpty(userId))
            {
                userName = _identityContext.GetUserName();
            }

            _logger.LogWarning("CleanArchitecture Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@UserId} {@UserName} {@Request}",
                requestName, elapsedMilliseconds, userId, userName, request);
        }

        return response;
    }
}

