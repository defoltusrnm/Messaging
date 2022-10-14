using Messaging.Domain.Packages.Interface;

namespace Messaging.Domain.Handlers.Interfaces;

public interface IHandlersMediator
{
    Task SendAsync(IPackage package, CancellationToken cancellationToken = default);
}
