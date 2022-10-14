using Messaging.Domain.Contextes.Interfaces;
using Messaging.Domain.Packages.Interface;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Messaging.Networking.Tcp.Contextes;

public class NetworkContext : ISessionContext
{
    private readonly NetworkStream _stream;
    
    public NetworkContext(string rawText, IPackage package, Encoding encoding, NetworkStream stream)
    {   
        _stream = stream;

        RawText = rawText;
        PreparedPackage = package;
        ClientEndPoint = stream.Socket.RemoteEndPoint!;
        Encoding = encoding;
    }
    
    public string RawText { get; }

    public IPackage PreparedPackage { get; }

    public EndPoint ClientEndPoint { get; }

    public Encoding Encoding { get; }

    public async Task WriteAsync(string rawText, CancellationToken cancellationToken = default)
    {
        await _stream.WriteAsync(Encoding.GetBytes($"{rawText}\n"), cancellationToken);
    }
}
