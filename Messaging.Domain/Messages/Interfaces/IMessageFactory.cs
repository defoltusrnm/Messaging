using Messaging.Domain.Commands.Interfaces;

namespace Messaging.Domain.Messages.Interfaces;

public interface IMessageFactory
{
    bool TryCreateMessage(ICommand command, string content, out IMessage message);
}

public interface IMessageFactory<TContent> : IMessageFactory
{
    bool TryCreateMessage(ICommand command, string content, out IMessage<TContent> message);
}