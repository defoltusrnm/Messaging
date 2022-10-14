using Messaging.Domain.Packages.Interface;

namespace Messaging.Domain.Senders.Interfaces;

public interface ISender
{
    Task ConnectAsync();
    Task SendAsync(IPackage package, CancellationToken cancellationToken = default);
}
