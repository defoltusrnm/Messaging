using Messaging.Domain.Commands.Interfaces;
using Messaging.Domain.Messages.Interfaces;
using Messaging.Domain.Messages.Primitives;

namespace Messaging.Console.Messages;

public class ConsoleMessageFactory : IMessageFactory<string>
{
    public bool TryCreateMessage(ICommand command, string content, out IMessage<string> message)
    {
        if (command.Path == "log")
        {
            message = new StringMessage(content);
            
            return true;
        }

        message = null;
        return false;
    }

    public bool TryCreateMessage(ICommand command, string content, out IMessage message)
    {
        if (command.Path == "log")
        {
            message = new StringMessage(content);

            return true;
        }

        message = null;
        return false;
    }
}
