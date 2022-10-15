using Messaging.Domain.Commands.Interfaces;
using Messaging.Domain.Messages.Interfaces;
using Messaging.Domain.Topologies.Primitives;

namespace Messaging.Domain.Messages.Primitives;

public class MessageMediator : IMessageMediator
{
    private readonly IServiceProvider _serviceProvider;
    private readonly MessageFactoryTopologies _factoryTopologies;

    public MessageMediator(IServiceProvider serviceProvider, 
                          MessageFactoryTopologies factoryTopologies)
    {
        _serviceProvider = serviceProvider;
        _factoryTopologies = factoryTopologies;
    }

    public IMessageFactory CreateFactory(ICommand command)
    {
        if (!_factoryTopologies.ContainsKey(command.Path))
        {
            throw new InvalidOperationException("No such command");
        }

        if (_serviceProvider.GetService(_factoryTopologies[command.Path]) is not IMessageFactory messageFactory)
        {
            throw new InvalidOperationException("DI exception");
        }

        return messageFactory;
    }
}
