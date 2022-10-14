using Messaging.Domain.Commands.Interfaces;
using Messaging.Domain.Messages.Interfaces;
using Messaging.Domain.Packages.Interface;
using Messaging.Networking.Tcp.Commands;

namespace Messaging.Networking.Tcp.Packages;

public class TcpPackage : IPackage
{
    public TcpPackage(TcpCommand command, IMessage message)
    {
        Command = command;
        Message = message;
    }
    
    public ICommand Command { get; }

    public IMessage Message { get; }
}
