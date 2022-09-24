using System.Threading.Tasks;

namespace ServerMessaging.SampleApplication.Infrastructure.Commands.Interfaces;

public interface IAsyncCommand
{
    bool IsRunning { get; }

    Task ExecuteAsync(object? parameter);
}
