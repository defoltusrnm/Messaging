using ServerMessaging.Terminal.Infrastructure.ViewModels.Base;

namespace ServerMessaging.Terminal.Infrastructure.Services.Interfaces;

public interface ILocator
{
    TViewModel? GetViewModel<TViewModel>()
        where TViewModel : ViewModelBase;
}
