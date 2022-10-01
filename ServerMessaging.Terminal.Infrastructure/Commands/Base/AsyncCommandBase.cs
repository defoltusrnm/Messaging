using ServerMessaging.Terminal.Infrastructure.Commands.Interfaces;
using System;
using System.Threading.Tasks;

namespace ServerMessaging.Terminal.Infrastructure.Commands.Base;

public abstract class AsyncCommandBase : CommandBase, IAsyncCommand
{
    public bool IsRunning { get; protected set; }

    public abstract Task ExecuteAsync(object? parameter);

    public override async void Execute(object? parameter)
    {
        try
        {
            IsRunning = true;
            await ExecuteAsync(parameter);
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            IsRunning = false;
            RaiseCanExecuteChanged();
        }
    }
}
