using Messaging.Domain.Contextes.Interfaces;

namespace Messaging.Domain.Handlers.Interfaces;

public interface IHandlersMediator
{
    Task SendAsync(ISessionContext context, CancellationToken cancellationToken = default);
}
