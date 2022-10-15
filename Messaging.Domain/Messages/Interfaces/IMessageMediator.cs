using Messaging.Domain.Commands.Interfaces;

namespace Messaging.Domain.Messages.Interfaces;

public interface IMessageMediator
{
    IMessageFactory CreateFactory(ICommand command);
}
