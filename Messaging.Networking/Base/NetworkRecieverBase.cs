using Messaging.Domain.Handlers.Interfaces;
using Messaging.Domain.Interceptors.Interfaces;
using Messaging.Domain.Packages.Interface;
using Messaging.Networking.Interfaces;
using System.Net.Sockets;
using System.Text;

namespace Messaging.Networking.Base;

public abstract class NetworkRecieverBase : INetworkReciever
{
    protected readonly CancellationTokenSource _cancellationTokenSource;
    protected IEnumerable<Task> _tasks;

    public NetworkRecieverBase(Encoding encoding,
                               int recieveSize,
                               IPackageProcessor? packageProcessor = null,
                               IHandlersMediator? handlersMediator = null,
                               IEnumerable<IPackageInterceptor>? packageInterceptors = null)
    {
        Encoding = encoding;
        RecieveSize = recieveSize;
        _cancellationTokenSource = new ();
        _tasks = Enumerable.Empty<Task>();

        PackageProcessor = packageProcessor;
        HandlersMediator = handlersMediator;
        PackageInterceptors = packageInterceptors;
    }

    public virtual IPackageProcessor? PackageProcessor { get; }

    public virtual IHandlersMediator? HandlersMediator { get; }

    public virtual IEnumerable<IPackageInterceptor>? PackageInterceptors { get; }

    public virtual int RecieveSize { get; }

    public virtual Encoding Encoding { get; }

    public virtual async Task StartAsync(CancellationToken cancellationToken = default)
    {
        StartListener();
        while (true)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                _cancellationTokenSource.Cancel();
                return;
            }

            var stream = await GetStream(_cancellationTokenSource.Token);
            _tasks = _tasks.Append(Task.Run(() => StartMessagingAsync(stream, _cancellationTokenSource.Token)));
        }
    }

    protected abstract void StartListener();
    protected abstract void StopListner();
    protected abstract Task<NetworkStream> GetStream(CancellationToken cancellationToken = default);

    public virtual async Task StopAsync()
    {
        _cancellationTokenSource.Cancel();
        await Task.WhenAll(_tasks);
        StopListner();
    }
    
    public abstract Task StartMessagingAsync(NetworkStream stream, CancellationToken cancellationToken = default);
}
