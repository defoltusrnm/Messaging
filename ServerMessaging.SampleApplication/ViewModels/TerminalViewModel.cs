using ServerMessaging.SampleApplication.Infrastructure.ViewModels.Base;

namespace ServerMessaging.SampleApplication.ViewModels;

public class TerminalViewModel : ViewModelBase
{
    private string _text = string.Empty;
    public string Text { get => _text; set => Set(ref _text, value); }

    private string _title = string.Empty;
    public string Title { get => _title; set => Set(ref _title, value); }
}
