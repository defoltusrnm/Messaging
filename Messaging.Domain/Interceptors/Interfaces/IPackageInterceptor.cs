using Messaging.Domain.Contextes.Interfaces;

namespace Messaging.Domain.Interceptors.Interfaces;

public interface IPackageInterceptor
{
    Task<bool> InterceptAsync(ISessionContext context, CancellationToken cancellationToken = default);
}
