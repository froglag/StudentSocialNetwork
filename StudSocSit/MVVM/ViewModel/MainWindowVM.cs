using StudSocSit.Store;
using System.Configuration.Internal;

namespace ViewModel;

public class MainWindowVM : ViewModelBase
{
    private readonly NavigationStore _navigationStore;
    public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;
    public MainWindowVM(NavigationStore navigationStore)
    {
        _navigationStore = navigationStore;
        _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
    }

    private void OnCurrentViewModelChanged()
    {
        OnPropertyChanged(nameof(CurrentViewModel));
    }

}
