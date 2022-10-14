using Messaging.Domain.Contextes.Interfaces;
using Messaging.Domain.Messages.Interfaces;

namespace Messaging.Domain.Handlers.Interfaces;

public interface IMessageHandler
{
    ISessionContext? Context { get; set; }
    Task HandleAsync(IMessage message, CancellationToken cancellationToken = default);
}

public interface IMessageHandler<TContent> : IMessageHandler
{
    Task HandleAsync(IMessage<TContent> message, CancellationToken cancellationToken = default);
}