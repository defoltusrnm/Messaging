namespace ServerMessaging.Lib.Infrastructure.Interfaces;

public interface IServerBehaviour
{
    IDictionary<SubscriberInfo, IClientBehaviour> Subscribers { get; }
    
    Task RunAsync(CancellationToken? cancellationToken = null);

    Task StopAsync(CancellationToken? cancellationToken = null);
}
