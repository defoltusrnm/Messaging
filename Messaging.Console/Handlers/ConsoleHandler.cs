using Messaging.Console.Services;
using Messaging.Domain.Handlers.Base;
using Messaging.Domain.Messages.Interfaces;

namespace Messaging.Console.Handlers;

public class ConsoleHandler : MessageHandlerBase<string>
{
    private readonly ConsoleService consoleService;

    public ConsoleHandler(ConsoleService consoleService)
    {
        this.consoleService = consoleService;
    }
    
    public override Task HandleAsync(IMessage<string> content, CancellationToken cancellationToken = default)
    {
        consoleService.Write(content.AsString());

        return Task.CompletedTask;
    }
}
