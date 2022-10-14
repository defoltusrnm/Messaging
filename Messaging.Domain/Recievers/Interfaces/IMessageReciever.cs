using Messaging.Domain.Handlers.Interfaces;
using Messaging.Domain.Interceptors.Interfaces;
using Messaging.Domain.Packages.Interface;

namespace Messaging.Domain.Recievers.Interfaces;

public interface IMessageReciever
{
    IPackageProcessor? PackageProcessor { get; }
    IHandlersMediator? HandlersMediator { get; }
    IEnumerable<IPackageInterceptor>? PackageInterceptors { get; }

    Task StartAsync(CancellationToken cancellationToken = default);
    Task StopAsync();
}
