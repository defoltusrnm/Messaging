using ServerMessaging.Lib.Infrastructure.Interfaces;

namespace ServerMessaging.PlaygroundServer
{
    public class LoggingServer : IServerBehaviour
    {
        private readonly IServerBehaviour _server;

        public LoggingServer(IServerBehaviour server)
        {
            _server = server;
        }

        public void Dispose()
        {
            _server.Dispose();
        }

        public Task RunAsync(CancellationToken? cancellationToken = null)
        {
            Console.WriteLine("Server running");
            return _server.RunAsync(cancellationToken);
        }

        public Task SendAsync<TData>(IMessage<TData> message, CancellationToken? cancellationToken = null)
        {
            Console.WriteLine("Sending data");
            return _server.SendAsync(message, cancellationToken);
        }

        public Task StopAsync(CancellationToken? cancellationToken = null)
        {
            Console.WriteLine("Stoping server");
            return _server.StopAsync();
        }
    }
}
