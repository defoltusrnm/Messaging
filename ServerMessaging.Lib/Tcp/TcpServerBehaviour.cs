using ServerMessaging.Lib.Infrastructure.Interfaces;
using ServerMessaging.Lib.Infrastructure.Primirives;
using System.Net.Sockets;
using System.Net;

namespace ServerMessaging.Lib.Tcp;

public class TcpServerBehaviour : IServerBehaviour
{
    private readonly TcpListener _listener;
    private readonly IDictionary<SubscriberInfo, Task> _runningTask = new Dictionary<SubscriberInfo, Task>();
    private readonly ISubscriberHandler _subscriberHandler;

    public TcpServerBehaviour(IPEndPoint endPoint, ISubscriberHandler subscriberHandler)
    {
        _listener = new TcpListener(endPoint);
        _subscriberHandler = subscriberHandler;
    }

    public IDictionary<SubscriberInfo, IClientBehaviour> Subscribers => new Dictionary<SubscriberInfo, IClientBehaviour>();

    public void Dispose()
    {
        _listener.Server.Dispose();
        GC.SuppressFinalize(this);
    }

    public Task RunAsync(CancellationToken cancellationToken = default)
    {
        _listener.Start();
        return Task.Run(() => ProccessRequests(cancellationToken));
    }

    public async Task StopAsync(CancellationToken cancellationToken = default)
    {
        await Task.WhenAll(_runningTask.Values);
        _runningTask.Clear();
        _listener.Stop();
    }

    protected async Task ProccessRequests(CancellationToken cancellationToken = default)
    {
        while (true)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            TcpClient client = await _listener.AcceptTcpClientAsync();
            EndPoint endpoint = client.Client.RemoteEndPoint ?? throw new Exception("dwada");

            SubscriberInfo info = new()
            {
                Address = endpoint.ToString(),
                Port = 500
            };
            IClientBehaviour behaviour = new TcpClientBehaviour(client);

            var stream = client.GetStream();
            byte[] readBytes = new byte[256];

            await stream.ReadAsync(readBytes, 0, readBytes.Length, cancellationToken);

            var message = new ByteMessage
            {
                Data = readBytes.Where(b => b != '\0').ToArray()
            };

            Subscribers.Add(info, behaviour);
            _runningTask.Add(info, _subscriberHandler.HandleAsync(message, cancellationToken));
        }
    }
}
