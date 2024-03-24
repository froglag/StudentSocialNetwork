using StudSocSit.Store;
using ViewModel;
using ViewModel.Commands;

namespace Commands;
public class NavigateToLoginPageCommand : CommandBase
{
    private readonly NavigationStore _navigationStore;

    public NavigateToLoginPageCommand(NavigationStore navigation)
    {
        _navigationStore = navigation;
    }
    public override void Execute(object? parameter)
    {
        _navigationStore.CurrentViewModel = new LoginVM(_navigationStore);
    }
}
