using ServerMessaging.Lib.Infrastructure.Interfaces;
using System.Net;
using System.Net.Sockets;

namespace ServerMessaging.Lib.Tcp;

public class TcpClientBehaviour : IClientBehaviour
{
    private readonly TcpClient _client;
    private readonly IPEndPoint _endPoint;

    public TcpClientBehaviour(IPEndPoint endPoint)
    {
        _endPoint = endPoint;
        _client = new TcpClient();
    }

    public TcpClientBehaviour(TcpClient client)
    {
        _client = client;
        _endPoint = (IPEndPoint)client.Client.RemoteEndPoint!;
    }

    public Task ConnectAsync(CancellationToken cancellationToken = default)
    {
        return _client.ConnectAsync(_endPoint);
    }

    public Task DisconnectAsync(CancellationToken cancellationToken = default)
    {
        return _client.Client.DisconnectAsync(false, cancellationToken).AsTask();
    }

    public void Dispose()
    {
        _client.Dispose();
        GC.SuppressFinalize(this);
    }

    public Task SendAsync<TData>(IMessage<TData> message, CancellationToken cancellationToken = default) where TData : class
    {
        ArraySegment<byte> bytes = new(message.AsBytes().Data.ToArray());

        return _client.Client.SendAsync(bytes, SocketFlags.None, cancellationToken).AsTask();
    }
}
