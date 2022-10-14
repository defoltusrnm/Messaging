﻿using Messaging.Domain.Contextes.Interfaces;
using Messaging.Domain.Handlers.Interfaces;

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

    public async Task SendAsync(ISessionContext context, CancellationToken cancellationToken = default)
    {
        if (!_handlerTopologies.ContainsKey(context.PreparedPackage.Command.Path))
        {
            throw new InvalidOperationException("No message handler for such command");
        }
        
        var handlerType = _handlerTopologies[context.PreparedPackage.Command.Path];

        if (_serviceProvider.GetService(handlerType) is not IMessageHandler handler)
        {
            throw new InvalidOperationException("DI exception");
        }

        handler.Context = context;
        await handler.HandleAsync(context.PreparedPackage.Message, cancellationToken);
    }
}
