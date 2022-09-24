using ServerMessaging.Lib.Infrastructure.Interfaces;
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
    }

    public Task RunAsync(CancellationToken? cancellationToken = null)
    {
        throw new NotImplementedException();
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

            }

            TcpClient client = await _listener.AcceptTcpClientAsync();
            // add subsc
        }
    }
}
