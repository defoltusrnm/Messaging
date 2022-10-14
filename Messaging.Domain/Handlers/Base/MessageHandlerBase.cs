using Messaging.Domain.Handlers.Interfaces;
using Messaging.Domain.Messages.Interfaces;

namespace Messaging.Domain.Handlers.Base;

public abstract class MessageHandlerBase<TContent> : IMessageHandler<TContent>
{
    public abstract Task HandleAsync(IMessage<TContent> message, CancellationToken cancellationToken = default);

    Task IMessageHandler.HandleAsync(IMessage message, CancellationToken cancellationToken = default)
    {
        if (message is not IMessage<TContent> messageWithContent)
        {
            throw new InvalidOperationException("Cannot cast");
        }

        return HandleAsync(messageWithContent, cancellationToken);
    }
}
