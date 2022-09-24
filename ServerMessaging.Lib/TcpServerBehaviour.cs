using ServerMessaging.Lib.Infrastructure.Interfaces;
using System.Net;
using System.Net.Sockets;

namespace ServerMessaging.Lib;

public class TcpServerBehaviour : IServerBehaviour
{
    private readonly TcpListener _listener;

    public TcpServerBehaviour(IPEndPoint endPoint)
    {
        _listener = new TcpListener(endPoint);
    }

    public void Dispose()
    {
        _listener.Server.Dispose();
    }

    public Task RunAsync(CancellationToken? cancellationToken = null)
    {
        _listener.Start();
        return Task.CompletedTask;
    }

    public Task SendAsync<TData>(IMessage<TData> message, CancellationToken? cancellationToken = null)
    {
        ArraySegment<byte> segment = new (message.AsBytes().Message.ToArray());
        return _listener.Server.SendAsync(segment, SocketFlags.None);
    }

    public Task StopAsync(CancellationToken? cancellationToken = null)
    {
        _listener.Stop();
        return Task.CompletedTask;
    }

    private void Proccess(CancellationToken? cancellationToken = null)
    {
        while (CheckToken(cancellationToken))
        {

        }
    }

    private bool CheckToken(CancellationToken? cancellationToken) 
    {
        if (cancellationToken == null)
        {
            return true;
        }

        return !cancellationToken.Value.IsCancellationRequested;
    }
}
