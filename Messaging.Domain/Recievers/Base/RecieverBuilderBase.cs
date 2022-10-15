using Messaging.Domain.Handlers.Interfaces;
using Messaging.Domain.Interceptors.Interfaces;
using Messaging.Domain.Messages.Interfaces;
using Messaging.Domain.Packages.Interface;
using Messaging.Domain.Recievers.Interfaces;
using Messaging.Domain.Topologies.Primitives;
using Microsoft.Extensions.DependencyInjection;

namespace Messaging.Domain.Recievers.Base;

public abstract class RecieverBuilderBase : IRecieverBuilder
{
    protected readonly IServiceCollection _services;
    private readonly HandlerTopologies _handlerTopologies;
    private readonly MessageFactoryTopologies _messagesTopologies;

    public RecieverBuilderBase()
    {
        _services = new ServiceCollection();
        _handlerTopologies = new();
        _messagesTopologies = new();

        _services.AddScoped<IServiceProvider, ServiceProvider>()
                 .AddSingleton(_handlerTopologies)
                 .AddSingleton(_messagesTopologies);
    }

    public IServiceCollection Services => _services;

    public abstract IMessageReciever Build();

    public virtual IRecieverBuilder AddCommand<TMessageHandler>(string command) where TMessageHandler : class, IMessageHandler
    {
        if (_handlerTopologies.ContainsKey(command))
        {
            throw new InvalidOperationException("Such command already exists");
        }

        _handlerTopologies.Add(command, typeof(TMessageHandler));
        _services.AddScoped<TMessageHandler>();

        return this;
    }

    public virtual IRecieverBuilder AddInterceptor<TInterceptor>() where TInterceptor : class, IPackageInterceptor
    {
        _services.AddScoped<IPackageInterceptor, TInterceptor>();

        return this;
    }

    public virtual IRecieverBuilder AddMessageFactory<TMessageFactory>(string command) where TMessageFactory : class, IMessageFactory
    {
        if (_messagesTopologies.ContainsKey(command))
        {
            throw new InvalidOperationException("Such command already exists");
        }

        _messagesTopologies.Add(command, typeof(TMessageFactory));
        _services.AddScoped<TMessageFactory>();

        return this;
    }

    public virtual IRecieverBuilder UseHandlerMediator<TMediator>() where TMediator : class, IHandlersMediator
    {
        _services.AddSingleton<IHandlersMediator, TMediator>();

        return this;
    }

    public virtual IRecieverBuilder UseMessageMediator<TMediator>() where TMediator : class, IMessageMediator
    {
        _services.AddSingleton<IMessageMediator, TMediator>();

        return this;
    }

    public virtual IRecieverBuilder UsePackageProcessor<TProcessor>() where TProcessor : class, IPackageProcessor
    {
        _services.AddSingleton<IPackageProcessor, TProcessor>();

        return this;
    }
}
