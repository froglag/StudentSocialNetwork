using StudSocSit.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using ViewModel.Commands;

namespace Commands;
public class NavigateToSinginPageCommand : CommandBase
{
    private readonly HttpClient _client;
    private readonly NavigationStore _navigationStore;

    public NavigateToSinginPageCommand(NavigationStore navigation, HttpClient client)
    {
        _client = client;
        _navigationStore = navigation;
    }
    public override void Execute(object? parameter)
    {
        _navigationStore.CurrentViewModel = new SighupVM(_navigationStore, _client);
    }
}
