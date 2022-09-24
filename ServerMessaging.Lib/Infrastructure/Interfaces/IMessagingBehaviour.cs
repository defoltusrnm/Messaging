namespace ServerMessaging.Lib.Infrastructure.Interfaces;

public interface IMessagingBehaviour
{
    Task SendAsync<TData>(IMessage<TData> message, CancellationToken? cancellationToken = null);
}
