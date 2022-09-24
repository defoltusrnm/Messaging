using ServerMessaging.Lib.Infrastructure.Interfaces;
using ServerMessaging.Lib.Infrastructure.Primirives;
using System.Net;
using System.Net.Sockets;

namespace ServerMessaging.Samples;

public class TcpServerBehaviour : IServerBehaviour
{
    private readonly TcpListener _listener;
    private readonly IDictionary<SubscriberInfo, Task> _runningTask = new Dictionary<SubscriberInfo, Task>();

    public TcpServerBehaviour(IPEndPoint endPoint)
    {
        _listener = new TcpListener(endPoint);
    }

    public IDictionary<SubscriberInfo, IClientBehaviour> Subscribers => new Dictionary<SubscriberInfo, IClientBehaviour>();

    public void Dispose()
    {
        _listener.Server.Dispose();
        GC.SuppressFinalize(this);
    }

    public Task RunAsync(CancellationToken? cancellationToken = null)
    {
        _listener.Start();
        return Task.Run(() => ProccessRequests(cancellationToken));
    }

    public async Task StopAsync(CancellationToken? cancellationToken = null)
    {
        await Task.WhenAll(_runningTask.Values);
        _runningTask.Clear();
        _listener.Stop();
    }

    protected async Task ProccessRequests(CancellationToken? cancellationToken = null)
    {
        while (true)
        {
            if (cancellationToken.HasValue && cancellationToken.Value.IsCancellationRequested)
            {
                return;
            }

            TcpClient client = await _listener.AcceptTcpClientAsync();
            SubscriberInfo info = new()
            {
                Address = "GetLater",
                Port = 500
            };
            IClientBehaviour behaviour = new TcpClientBehaviour(client);
            ISubscriberHandler subscriberHandler = new SimpleTcpHandler(behaviour, info);

            var stream = client.GetStream();
            byte[] readBytes = new byte[256];
            
            if (cancellationToken == null)
            {
                await stream.ReadAsync(readBytes, 0, readBytes.Length);
            }
            else
            {
                await stream.ReadAsync(readBytes, 0, readBytes.Length, cancellationToken.Value);
            }
            
            var message = new ByteMessage
            {
                Data = readBytes.Where(b => b != '\0').ToArray()
            };
            
            Subscribers.Add(info, behaviour);
            _runningTask.Add(info, subscriberHandler.HandleAsync(message, cancellationToken));
        }
    }
}
