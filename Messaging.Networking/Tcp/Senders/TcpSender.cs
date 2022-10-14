using Messaging.Domain.Packages.Interface;
using Messaging.Domain.Senders.Interfaces;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Messaging.Networking.Tcp.Senders;

public class TcpSender : ISender
{
    private readonly TcpClient _tcpClient;
    private readonly IPEndPoint _endPoint;
    private NetworkStream? _stream;

    public TcpSender(IPEndPoint endPoint)
    {
        _tcpClient = new TcpClient();
        _endPoint = endPoint;
    }

    public async Task ConnectAsync()
    {
        await _tcpClient.ConnectAsync(_endPoint);
        _stream = _tcpClient.GetStream();
    }

    public async Task SendAsync(IPackage package, CancellationToken cancellationToken = default)
    {
        if (_stream == null) 
        {
            throw new InvalidOperationException("Not connected");
        }
        
        var command = Encoding.UTF8.GetBytes($"{package.Command.Path} {package.Message.AsString()}\n");

        await _stream.WriteAsync(command.AsMemory(), cancellationToken);
    }
}
