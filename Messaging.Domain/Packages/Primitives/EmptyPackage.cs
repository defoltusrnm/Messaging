using Messaging.Domain.Commands.Interfaces;
using Messaging.Domain.Messages.Interfaces;
using Messaging.Domain.Packages.Interface;

namespace Messaging.Domain.Packages.Primitives;

public class EmptyPackage : IPackage
{
    public EmptyPackage()
    {
        Command = ICommand.Empty;
        Message = IMessage.Empty;
    }
    
    public ICommand Command { get; }

    public IMessage Message { get; }
}
