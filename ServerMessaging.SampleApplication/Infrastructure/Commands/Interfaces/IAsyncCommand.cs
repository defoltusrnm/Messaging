using System.Threading.Tasks;
using System.Windows.Input;

namespace ServerMessaging.SampleApplication.Infrastructure.Commands.Interfaces;

public interface IAsyncCommand : ICommand
{
    bool IsRunning { get; }

    Task ExecuteAsync(object? parameter);
}
