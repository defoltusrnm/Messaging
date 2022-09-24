namespace ServerMessaging.Lib.Infrastructure.Interfaces;

public interface IServerBehaviour : IMessagingBehaviour
{
    HashSet<SubscriberInfo> Subscribers { get; }
    
    Task RunAsync(CancellationToken? cancellationToken = null);

    Task StopAsync(CancellationToken? cancellationToken = null);
}
