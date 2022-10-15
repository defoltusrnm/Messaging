using Messaging.Domain.Messages.Interfaces;
using Messaging.Domain.Packages.Interface;
using Messaging.Networking.Tcp.Commands;

namespace Messaging.Networking.Tcp.Packages;

public class PackageProcessor : IPackageProcessor
{
    private readonly IMessageMediator _messageMediator;

    public PackageProcessor(IMessageMediator messageFactory)
    {
        _messageMediator = messageFactory;
    }

    public IPackage Construct(string content)
    {
        if (string.IsNullOrWhiteSpace(content))
        {
            return IPackage.Empty;
        }

        var command = new TcpCommand(content.Split(' ')[0]);
        var commandParams = content.Remove(0, command.Path.Length + 1);

        if (string.IsNullOrWhiteSpace(commandParams)) 
        {
            return new TcpPackage(command, IMessage.Empty);
        }

        return new TcpPackage(command, _messageMediator.CreateFactory(command).Create(commandParams));
    }

    public string Deconsturct(IPackage package) => $"{package.Command.Path} {package.Message.AsString()}\n";
}
