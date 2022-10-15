using Messaging.Domain.Handlers.Interfaces;
using Messaging.Domain.Interceptors.Interfaces;
using Messaging.Domain.Messages.Interfaces;
using Messaging.Domain.Packages.Interface;
using Messaging.Domain.Recievers.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System.Net;

namespace Messaging.Networking.Tcp.Reciever;

public class TcpRecieverBuilder : IRecieverBuilder
{
    private readonly IServiceCollection _services;
    private readonly IDictionary<string, Type> _handlerTopologies;

    public TcpRecieverBuilder(IPEndPoint endPoint)
    {
        _services = new ServiceCollection();
        
        _handlerTopologies = new Dictionary<string, Type>();
        
        _services.AddScoped<IServiceProvider, ServiceProvider>().AddSingleton(endPoint);
    }

    public IServiceCollection Services => _services;
    
    public IMessageReciever Build()
    {
        _services.AddSingleton(_handlerTopologies);
        _services.AddScoped<TcpMessageReciever>();

        return _services.BuildServiceProvider().GetService<TcpMessageReciever>() ?? throw new NullReferenceException("Cant create message reciever");
    }

    public IRecieverBuilder AddCommand<TMessageHandler>(string command) where TMessageHandler : class, IMessageHandler
    {
        if (_handlerTopologies.ContainsKey(command))
        {
            throw new InvalidOperationException("Such command already exists");
        }
        
        _handlerTopologies.Add(command, typeof(TMessageHandler));
        _services.AddScoped<TMessageHandler>();

        return this;
    }

    public IRecieverBuilder AddInterceptor<TInterceptor>() where TInterceptor : class, IPackageInterceptor
    {
        _services.AddScoped<IPackageInterceptor, TInterceptor>();

        return this;
    }

    public IRecieverBuilder AddMessageFactory<TFactory>() where TFactory : class, IMessageFactory
    {
        _services.AddScoped<IMessageFactory, TFactory>();

        return this;
    }

    public IRecieverBuilder UseHandlerMediator<TMediator>() where TMediator : class, IHandlersMediator
    {
        _services.AddSingleton<IHandlersMediator, TMediator>();

        return this;
    }

    public IRecieverBuilder UsePackageProcessor<TProcessor>() where TProcessor : class, IPackageProcessor
    {
        _services.AddSingleton<IPackageProcessor, TProcessor>();

        return this;
    }
}
