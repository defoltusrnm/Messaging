namespace ServerMessaging.Lib.Infrastructure.Interfaces;

public interface IClientBehaviour : IMessagingBehaviour
{
    Task ConnectAsync(CancellationToken? cancellationToken = null);
    
    Task DisconnectAsync(CancellationToken? cancellationToken = null);
}
