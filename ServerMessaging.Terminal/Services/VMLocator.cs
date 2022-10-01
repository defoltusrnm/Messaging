using Microsoft.Extensions.DependencyInjection;
using ServerMessaging.Terminal.Infrastructure.Services.Base;
using ServerMessaging.Terminal.ViewModels;

namespace ServerMessaging.Terminal.Services;

public class VMLocator : LocatorBase
{
    public TerminalHostVM? TerminalHost => GetViewModel<TerminalHostVM>();
    
    protected override void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton(services)
                .AddSingleton(this)
                .AddScoped<TerminalHostVM>();
    }
}
