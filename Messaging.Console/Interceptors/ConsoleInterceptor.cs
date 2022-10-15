using Messaging.Domain.Contextes.Interfaces;
using Messaging.Domain.Interceptors.Interfaces;

namespace Messaging.Console.Interceptors
{
    public class ConsoleInterceptor : IPackageInterceptor
    {
        public Task<bool> InterceptAsync(ISessionContext context, CancellationToken cancellationToken = default)
        {
            System.Console.WriteLine($"client {context.ClientEndPoint} raw text {context.RawText}");

            return Task.FromResult(true);
        }
    }
}
