using Microsoft.Extensions.DependencyInjection;
using ServerMessaging.Terminal.Infrastructure.Services.Interfaces;
using ServerMessaging.Terminal.Infrastructure.ViewModels.Base;
using System;

namespace ServerMessaging.Terminal.Infrastructure.Services.Base;

public abstract class LocatorBase : ILocator
{
    protected readonly IServiceCollection _services;
    protected readonly IServiceProvider _provider;

    public LocatorBase()
    {
        _services = new ServiceCollection();
        ConfigureServices(_services);
        _provider = _services.BuildServiceProvider();
    }

    public TViewModel? GetViewModel<TViewModel>() where TViewModel : ViewModelBase => _provider.GetService<TViewModel>();

    protected abstract void ConfigureServices(IServiceCollection services);
}
