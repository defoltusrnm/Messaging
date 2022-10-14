using Messaging.Domain.Messages.Interfaces;
using Messaging.Domain.Packages.Interface;
using Messaging.Networking.Tcp.Commands;

namespace Messaging.Networking.Tcp.Packages;

public class PackageProcessor : IPackageProcessor
{
    public PackageProcessor(IEnumerable<IMessageFactory> messageFactories)
    {
        MessageFactories = messageFactories;
    }
    
    public IEnumerable<IMessageFactory>? MessageFactories { get; }

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

        foreach (var factory in MessageFactories ?? Enumerable.Empty<IMessageFactory>())
        {
            if (factory.TryCreateMessage(command, commandParams, out IMessage message))
            {
                return new TcpPackage(command, message);
            }
        }

        throw new InvalidOperationException($"No message topology for command {command.Path}");
    }

    public string Deconsturct(IPackage package) => $"{package.Command.Path} {package.Message.AsString()}\n";
}
