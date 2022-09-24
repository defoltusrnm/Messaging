namespace ServerMessaging.Lib.Infrastructure.Interfaces;

public interface ISubscriberHandler
{
    SubscriberInfo SubscriberInfo { get; }

    Task HandleAsync<TData>(IMessage<TData> message, CancellationToken cancellationToken = default)
        where TData : class;

    Task RespondAsync<TData>(IMessage<TData> message, CancellationToken cancellationToken = default)
        where TData : class;
}
