namespace ServerMessaging.Lib.Infrastructure.Interfaces;

public interface IServerBehaviour : IDisposable
{
    IDictionary<SubscriberInfo, IClientBehaviour> Subscribers { get; }
    
    Task RunAsync(CancellationToken? cancellationToken = null);

    Task StopAsync(CancellationToken? cancellationToken = null);
}
