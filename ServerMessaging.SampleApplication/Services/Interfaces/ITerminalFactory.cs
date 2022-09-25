using ServerMessaging.SampleApplication.ViewModels;

namespace ServerMessaging.SampleApplication.Services.Interfaces;

public interface ITerminalFactory
{
    TerminalViewModel Create();
}
