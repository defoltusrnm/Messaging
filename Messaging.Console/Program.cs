using Messaging.Console.Handlers;
using Messaging.Console.Messages;
using Messaging.Console.Services;
using Messaging.Domain.Handlers.Primitives;
using Messaging.Domain.Messages.Primitives;
using Messaging.Domain.Senders.Interfaces;
using Messaging.Networking.Tcp.Commands;
using Messaging.Networking.Tcp.Packages;
using Messaging.Networking.Tcp.Reciever;
using Messaging.Networking.Tcp.Senders;
using Microsoft.Extensions.DependencyInjection;
using System.Net;

namespace Messaging.Console;

public class Program
{
    public static async Task Main(string[] args)
    {
        var services = new ServiceCollection();
        services.AddScoped<ConsoleService>();
        var buidler = new TcpRecieverBuilder(services, IPEndPoint.Parse("127.0.0.1:5000"));

        buidler.AddMessageFactory<ConsoleMessageFactory>()
               .AddCommand<ConsoleHandler>(new TcpCommand("log").Path)
               .UseHandlerMediator<HandlersMediator>()
               .UsePackageProcessor<PackageProcessor>();

        var reciever = buidler.Build();
        var t1 = Task.Run(() => reciever.StartAsync());

        var sender = new TcpSender(IPEndPoint.Parse("127.0.0.1:5000"));
        var t2 = Task.Run(() => RunSender(sender, "Hello from sender 1", 500));

        var sender2 = new TcpSender(IPEndPoint.Parse("127.0.0.1:5000"));
        var t3 = Task.Run(() => RunSender(sender2, "Hello from sender 2", 600));

        await Task.WhenAll(t1, t2, t3);
    }

    public static async Task RunSender(ISender sender, string messageBase, int delay)
    {
        await sender.ConnectAsync();

        int i = 0;
        while (true)
        {
            await Task.Delay(delay);

            var pac = new TcpPackage(new TcpCommand("log"), new StringMessage($"{messageBase} {++i}"));

            await sender.SendAsync(pac);
        }
    }
}