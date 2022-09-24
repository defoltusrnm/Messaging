using ServerMessaging.Samples;
using System.Net;

using var server = new TcpServerBehaviour(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000));

await server.RunAsync();