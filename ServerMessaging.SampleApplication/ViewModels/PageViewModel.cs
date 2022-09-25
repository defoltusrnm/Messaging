using ServerMessaging.SampleApplication.Infrastructure.ViewModels.Base;

#nullable disable

namespace ServerMessaging.SampleApplication.ViewModels;

public class PageViewModel : ViewModelBase
{
    private string _title = string.Empty;
    public string Title { get => _title; set => Set(ref _title, value); }

    private TerminalViewModel _terminalViewModel;
    public TerminalViewModel TerminalViewModel { get => _terminalViewModel; set => Set(ref _terminalViewModel, value); }

    private ConnectionSettingsViewModel _connectionSettingsViewModel;
    public ConnectionSettingsViewModel ConnectionSettingsViewModel { get => _connectionSettingsViewModel; set => Set(ref _connectionSettingsViewModel, value);}
}
