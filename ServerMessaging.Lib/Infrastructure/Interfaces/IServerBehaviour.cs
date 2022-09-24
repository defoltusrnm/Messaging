namespace ServerMessaging.Lib.Infrastructure.Interfaces;

public interface IServerBehaviour : IMessagingBehaviour
{
    Task RunAsync(CancellationToken? cancellationToken = null);

    Task StopAsync(CancellationToken? cancellationToken = null);
}
