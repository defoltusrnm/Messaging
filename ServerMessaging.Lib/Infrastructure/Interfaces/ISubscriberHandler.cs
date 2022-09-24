namespace ServerMessaging.Lib.Infrastructure.Interfaces;

public interface ISubscriberHandler
{
    SubscriberInfo SubscriberInfo { get; }

    Task HandleAsync<TData>(IMessage<TData> message, CancellationToken? cancellationToken = null)
        where TData : class;
}
