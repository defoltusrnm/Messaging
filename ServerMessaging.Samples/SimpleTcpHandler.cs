using ServerMessaging.Lib.Infrastructure.Base;
using ServerMessaging.Lib.Infrastructure.Interfaces;

namespace ServerMessaging.Samples;

public class SimpleTcpHandler : SubscriberHandlerBase
{
    public SimpleTcpHandler(IClientBehaviour clientBehaviour, 
                            SubscriberInfo subscriberInfo) 
        : base(clientBehaviour, subscriberInfo)
    { }

    public override async Task HandleAsync<TData>(IMessage<TData> message, CancellationToken? cancellationToken = null) where TData : class
    {
        await Console.Out.WriteLineAsync(message.AsString().Data);
    }
}
