using Messaging.Domain.Messages.Interfaces;
using Messaging.Domain.Messages.Primitives;

namespace Messaging.Console.Messages;

public class ConsoleMessageFactory : IMessageFactory
{
    public IMessage Create(string content)
    {
        return new StringMessage(content);
    }
}
