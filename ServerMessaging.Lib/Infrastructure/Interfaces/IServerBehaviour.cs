namespace ServerMessaging.Lib.Infrastructure.Interfaces;

public interface IServerBehaviour : IDisposable
{
    IDictionary<SubscriberInfo, IClientBehaviour> Subscribers { get; }
    
    Task RunAsync(CancellationToken cancellationToken = default);

    Task StopAsync(CancellationToken cancellationToken = default);
}
