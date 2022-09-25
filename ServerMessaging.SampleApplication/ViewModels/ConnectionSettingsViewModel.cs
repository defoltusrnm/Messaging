using ServerMessaging.SampleApplication.Infrastructure.ViewModels.Base;

namespace ServerMessaging.SampleApplication.ViewModels;

public class ConnectionSettingsViewModel : ViewModelBase
{
    private string _address = string.Empty;
    public string Address { get => _address; set => Set(ref _address, value); }

    public uint _port = 0;
    public uint Port { get => _port; set => Set(ref _port, value); }

    private bool _isServer = false;
    public bool IsServer { get => _isServer; set => Set(ref _isServer, value); }
}
