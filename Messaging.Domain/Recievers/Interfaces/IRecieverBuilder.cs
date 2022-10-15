using Messaging.Domain.Handlers.Interfaces;
using Messaging.Domain.Interceptors.Interfaces;
using Messaging.Domain.Messages.Interfaces;
using Messaging.Domain.Packages.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Messaging.Domain.Recievers.Interfaces;

public interface IRecieverBuilder
{
    IServiceCollection Services { get; }
    IRecieverBuilder UsePackageProcessor<TProcessor>() where TProcessor : class, IPackageProcessor;
    IRecieverBuilder UseHandlerMediator<TMediator>() where TMediator : class, IHandlersMediator;
    IRecieverBuilder UseMessageMediator<TMediator>() where TMediator : class, IMessageMediator;
    IRecieverBuilder AddInterceptor<TInterceptor>() where TInterceptor : class, IPackageInterceptor;
    IRecieverBuilder AddMessageFactory<TMessageFactory>(string command) where TMessageFactory : class, IMessageFactory;
    IRecieverBuilder AddCommand<TMessageHandler>(string command) where TMessageHandler : class, IMessageHandler;
    IMessageReciever Build();
}
