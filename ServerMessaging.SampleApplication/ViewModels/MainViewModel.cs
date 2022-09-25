using ServerMessaging.SampleApplication.Infrastructure.ViewModels.Base;
using System.Collections.ObjectModel;

namespace ServerMessaging.SampleApplication.ViewModels;

public class MainViewModel : ViewModelBase
{
    public MainViewModel()
    {
        Terminals.Add(new PageViewModel()
        {
            Title = "New Page",
            TerminalViewModel = new TerminalViewModel()
            {
                Text = "dwadawdawda",
                Promt = ">"
            }
        });
    }
    
    private ObservableCollection<PageViewModel> _terminals = new();
    public ObservableCollection<PageViewModel> Terminals => _terminals;
}
