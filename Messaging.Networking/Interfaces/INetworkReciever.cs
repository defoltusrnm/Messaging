using Messaging.Domain.Recievers.Interfaces;
using System.Net.Sockets;
using System.Text;

namespace Messaging.Networking.Interfaces;

public interface INetworkReciever : IMessageReciever
{
    int RecieveSize { get; }
    Encoding Encoding { get; }
    Task StartMessagingAsync(NetworkStream stream, CancellationToken cancellationToken = default);
}
