using Messaging.Domain.Commands.Interfaces;

namespace Messaging.Networking.Tcp.Commands;

public class TcpCommand : ICommand
{
    public TcpCommand(string path)
    {
        Path = path;
    }

    public string Path { get; }

    public override int GetHashCode()
    {
        var hasCode = new HashCode();
        hasCode.Add(Path);

        return hasCode.ToHashCode();
    }
}
