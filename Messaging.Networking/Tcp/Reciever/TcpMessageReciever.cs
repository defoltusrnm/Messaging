using Messaging.Domain.Handlers.Interfaces;
using Messaging.Domain.Interceptors.Interfaces;
using Messaging.Domain.Packages.Interface;
using Messaging.Networking.Base;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Messaging.Networking.Tcp.Reciever;

public class TcpMessageReciever : NetworkRecieverBase
{
    private readonly TcpListener _tcpListener;

    public TcpMessageReciever(IPEndPoint endPoint, 
                              IPackageProcessor packageProcessor,
                              IHandlersMediator handlersMediator,
                              IEnumerable<IPackageInterceptor> packageInterceptors)
        : base(Encoding.UTF8, 256, packageProcessor, handlersMediator, packageInterceptors)
    {
        _tcpListener = new TcpListener(endPoint);
        _tasks = Enumerable.Empty<Task>();
    }

    public override async Task StartMessagingAsync(NetworkStream stream, CancellationToken cancellationToken = default)
    {
        if (HandlersMediator == null)
        {
            throw new ArgumentNullException(nameof(HandlersMediator));
        }

        while (true)
        {
            while (stream.DataAvailable)
            {
                var raw = await ReadIncomingString(stream, cancellationToken);

                if (string.IsNullOrWhiteSpace(raw))
                {
                    continue;
                }

                foreach (var rawText in raw.Split('\n'))
                {
                    var package = PackageProcessor?.Construct(rawText)
                                  ?? throw new ArgumentNullException(nameof(PackageProcessor));

                    if (package == IPackage.Empty)
                    {
                        continue;
                    }

                    bool isHandled = await InterceptPackage(package, cancellationToken);
                    if (isHandled)
                    {
                        continue;
                    }

                    await HandlersMediator.SendAsync(package, cancellationToken);
                }
            }
        }
    }

    protected override async Task<NetworkStream> GetStream(CancellationToken cancellationToken = default)
    {
        var client = await _tcpListener.AcceptTcpClientAsync();
        return client.GetStream();
    }

    protected override void StartListener()
    {
        _tcpListener.Start();
    }

    protected override void StopListner()
    {
        _tcpListener.Stop();
    }

    private async Task<string> ReadIncomingString(NetworkStream stream, CancellationToken cancellationToken = default)
    {
        var bytes = new byte[RecieveSize];
        await stream.ReadAsync(bytes, cancellationToken);

        return new string(Encoding.GetString(bytes).Where(c => c != '\0').ToArray()) 
            ?? throw new InvalidOperationException("Invalid bytes");
    }

    private async Task<bool> InterceptPackage(IPackage package, CancellationToken cancellationToken = default)
    {
        foreach (var interceptor in PackageInterceptors ?? Enumerable.Empty<IPackageInterceptor>())
        {
            bool isHandled = await interceptor.InterceptAsync(package, cancellationToken);

            if (isHandled)
            {
                return true;
            }
        }

        return false;
    }
}
