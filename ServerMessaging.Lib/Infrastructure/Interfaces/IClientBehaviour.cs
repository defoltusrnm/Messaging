namespace ServerMessaging.Lib.Infrastructure.Interfaces;

public interface IClientBehaviour : IMessagingBehaviour
{
    Task ConnectAsync(CancellationToken cancellationToken = default);
    
    Task DisconnectAsync(CancellationToken cancellationToken = default);
}
