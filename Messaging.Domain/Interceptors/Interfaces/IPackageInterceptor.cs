using Messaging.Domain.Packages.Interface;

namespace Messaging.Domain.Interceptors.Interfaces;

public interface IPackageInterceptor
{
    Task<bool> InterceptAsync(IPackage package, CancellationToken cancellationToken = default);
}
