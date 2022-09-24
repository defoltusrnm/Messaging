using ServerMessaging.SampleApplication.Infrastructure.ViewModels.Base;
using System.Collections.ObjectModel;

namespace ServerMessaging.SampleApplication.ViewModels;

public class MainViewModel : ViewModelBase
{
    public MainViewModel()
    {
        Terminals.Add(new TerminalViewModel()
        {
            Title = "Test",
            Text = "Test",
        });
    }
    
    private ObservableCollection<TerminalViewModel> _terminals = new();
    public ObservableCollection<TerminalViewModel> Terminals => _terminals;
}
