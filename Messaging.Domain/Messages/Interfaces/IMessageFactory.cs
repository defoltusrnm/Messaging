using Messaging.Domain.Commands.Interfaces;

namespace Messaging.Domain.Messages.Interfaces;

public interface IMessageFactory
{
    bool TryCreateMessage(ICommand command, string content, out IMessage message);
}