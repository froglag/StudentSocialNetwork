
using StudSocSit.Store;

namespace ViewModel;

public class MainWindowVM : ViewModelBase
{
    private readonly NavigationStore _navigationStore;
    public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;
    public MainWindowVM(NavigationStore navigationStore)
    {
        _navigationStore = navigationStore;
    }
}
