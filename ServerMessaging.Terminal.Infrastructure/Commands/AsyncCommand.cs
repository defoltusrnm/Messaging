using ServerMessaging.Terminal.Infrastructure.Commands.Base;
using System;
using System.Threading.Tasks;

namespace ServerMessaging.Terminal.Infrastructure.Commands;

public class AsyncCommand : AsyncCommandBase
{
    private readonly Func<object?, Task> _command;
    private readonly Predicate<object?>? _canExecute;

    public AsyncCommand(Func<object?, Task> command,
                        Predicate<object?>? canExecute = default)
    {
        _command = command;
        _canExecute = canExecute;
    }

    public override bool CanExecute(object? parameter) => _canExecute?.Invoke(parameter) ?? true && !IsRunning;

    public override Task ExecuteAsync(object? parameter) => _command(parameter);
}
