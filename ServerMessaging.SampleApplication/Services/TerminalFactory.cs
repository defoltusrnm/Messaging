using ServerMessaging.SampleApplication.Infrastructure.Locators;
using ServerMessaging.SampleApplication.Services.Interfaces;
using ServerMessaging.SampleApplication.ViewModels;

namespace ServerMessaging.SampleApplication.Services;

public class TerminalFactory : ITerminalFactory
{
    private readonly Locator _locator;

    public TerminalFactory(Locator locator)
    {
        _locator = locator;
    }

    public TerminalViewModel Create()
    {
        throw new System.Exception();
    }
}
