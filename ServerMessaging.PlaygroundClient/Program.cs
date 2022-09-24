using ServerMessaging.Lib.Infrastructure.Primirives;
using ServerMessaging.Samples;
using System.Net;

using var client = new TcpClientBehaviour(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000));

await client.ConnectAsync();
await client.SendAsync(new StringMessage { Data = "Hi" });
await client.DisconnectAsync();