using Microsoft.Extensions.DependencyInjection;
using ServerMessaging.SampleApplication.ViewModels;
using System;

namespace ServerMessaging.SampleApplication.Infrastructure.Locators;

public class Locator
{
    private readonly IServiceProvider _serviceProvider;

	public Locator()
	{
		_serviceProvider = new ServiceCollection().AddSingleton(this).AddScoped<MainViewModel>().BuildServiceProvider();
	}

	public MainViewModel? MainViewModel => _serviceProvider.GetService<MainViewModel>();

	public TerminalViewModel? TerminalViewModel => _serviceProvider.GetService<TerminalViewModel>();
}
