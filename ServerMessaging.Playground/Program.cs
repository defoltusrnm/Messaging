using ServerMessaging.Lib;
using ServerMessaging.Lib.Infrastructure.Interfaces;
using ServerMessaging.PlaygroundServer;
using System.Net;

using IServerBehaviour server = new LoggingServer(new TcpServerBehaviour(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000)));

server.RunAsync();
server.StopAsync();
