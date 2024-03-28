using MVVM.Model.DataFields;
using StudSocSit.Store;
using System.Net.Http;
using ViewModel;
using ViewModel.Commands;

namespace Commands;
public class NavigateToMainPageCommand : CommandBase
{
    private readonly NavigationStore _navigationStore;
    private readonly HttpClient _client;
    private readonly StudentModel _studentInfo;

    public NavigateToMainPageCommand(NavigationStore navigationStore, HttpClient client, StudentModel studentInfo)
    {
        _navigationStore = navigationStore;
        _client = client;
        _studentInfo = studentInfo;
    }
    public override void Execute(object? parameter)
    {
        if(_studentInfo != null)
        {
            _navigationStore.CurrentViewModel = new MainPageVM(_navigationStore, _client, _studentInfo);
        }
    }
}
