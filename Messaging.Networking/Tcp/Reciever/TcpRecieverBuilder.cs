using Messaging.Domain.Recievers.Base;
using Messaging.Domain.Recievers.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Net;

namespace Messaging.Networking.Tcp.Reciever;

public class TcpRecieverBuilder : RecieverBuilderBase
{
    public TcpRecieverBuilder(IPEndPoint endPoint)
    {        
        _services.AddSingleton(endPoint);
    }

    public override IMessageReciever Build()
    {
        _services.AddScoped<TcpMessageReciever>();

        return _services.BuildServiceProvider().GetRequiredService<TcpMessageReciever>();
    }
}
