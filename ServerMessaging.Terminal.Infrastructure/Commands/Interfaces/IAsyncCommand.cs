using System.Threading.Tasks;
using System.Windows.Input;

namespace ServerMessaging.Terminal.Infrastructure.Commands.Interfaces;

public interface IAsyncCommand : ICommand
{
    bool IsRunning { get; }

    Task ExecuteAsync(object? parameter);
}
