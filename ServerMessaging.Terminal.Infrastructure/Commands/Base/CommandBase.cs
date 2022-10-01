using System;
using System.Windows.Input;

namespace ServerMessaging.Terminal.Infrastructure.Commands.Base;

public abstract class CommandBase : ICommand
{
    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    public abstract bool CanExecute(object? parameter);

    public abstract void Execute(object? parameter);
    
    protected virtual void RaiseCanExecuteChanged() => CommandManager.InvalidateRequerySuggested();
}
