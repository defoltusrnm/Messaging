using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ServerMessaging.SampleApplication.Infrastructure.ViewModels.Base;

public abstract class ViewModelBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public void RaisePropertyChanged([CallerMemberName] string name = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name)); 
    }

    protected bool Set<TField>(ref TField field, TField value, [CallerMemberName] string name = "")
    {
        if (EqualityComparer<TField>.Default.Equals(field, value))
        {
            return false;
        }

        field = value;
        RaisePropertyChanged(name);
        return true;
    }
}
