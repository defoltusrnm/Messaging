using ServerMessaging.Lib.Infrastructure.Interfaces;

namespace ServerMessaging.Lib.Infrastructure.Base;

public abstract class SubscriberHandlerBase : ISubscriberHandler
{
    protected readonly IClientBehaviour _clientBehaviour;

    public SubscriberHandlerBase(IClientBehaviour clientBehaviour, SubscriberInfo subscriberInfo)
    {
        _clientBehaviour = clientBehaviour;
        SubscriberInfo = subscriberInfo;
    }

    public SubscriberInfo SubscriberInfo { get; }

    public abstract Task HandleAsync<TData>(IMessage<TData> message, CancellationToken cancellationToken = default) where TData : class;

    public abstract Task RespondAsync<TData>(IMessage<TData> message, CancellationToken cancellationToken = default) where TData : class;
}
