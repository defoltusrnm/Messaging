using Messaging.Domain.Commands.Interfaces;
using Messaging.Domain.Handlers.Interfaces;
using Messaging.Domain.Packages.Interface;

namespace Messaging.Domain.Handlers.Primitives;

public class HandlersMediator : IHandlersMediator
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IDictionary<string, Type> _handlerTopologies;

    public HandlersMediator(IServiceProvider serviceProvider, IDictionary<string, Type> handlersTopology)
    {
        _serviceProvider = serviceProvider;
        _handlerTopologies = handlersTopology;
    }

    public async Task SendAsync(IPackage package, CancellationToken cancellationToken = default)
    {
        if (!_handlerTopologies.ContainsKey(package.Command.Path))
        {
            throw new InvalidOperationException("No message handler for such command");
        }
        
        var handlerType = _handlerTopologies[package.Command.Path];

        if (_serviceProvider.GetService(handlerType) is not IMessageHandler handler)
        {
            throw new InvalidOperationException("DI exception");
        }

        await handler.HandleAsync(package.Message, cancellationToken);
    }
}
