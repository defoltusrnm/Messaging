using ServerMessaging.Terminal.Infrastructure.Commands.Interfaces;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ServerMessaging.Terminal.Infrastructure.Commands.Base;

public abstract class AsyncCommandBase : IAsyncCommand
{
    public bool IsRunning { get; protected set; }

    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    public abstract bool CanExecute(object? parameter);

    public abstract Task ExecuteAsync(object? parameter);

    public virtual async void Execute(object? parameter)
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

    protected void RaiseCanExecuteChanged() => CommandManager.InvalidateRequerySuggested();
}
