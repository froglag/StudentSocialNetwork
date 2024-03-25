using StudSocSit.Store;
using System.Net.Http;
using ViewModel;
using ViewModel.Commands;

namespace Commands;
public class NavigateToLoginPageCommand : CommandBase
{
    private readonly HttpClient _client;
    private readonly NavigationStore _navigationStore;

    public NavigateToLoginPageCommand(NavigationStore navigation, HttpClient client)
    {
        _client = client;
        _navigationStore = navigation;
    }
    public override void Execute(object? parameter)
    {
        _navigationStore.CurrentViewModel = new LoginVM(_navigationStore, _client);
    }
}
