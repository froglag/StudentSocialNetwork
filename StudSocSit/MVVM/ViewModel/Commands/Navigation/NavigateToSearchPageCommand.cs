using MVVM.Model.DataFields;
using StudSocSit.Store;
using System.Net.Http;
using ViewModel;
using ViewModel.Commands;

namespace Commands;
public class NavigateToSearchPageCommand : CommandBase
{
    private readonly NavigationStore _navigationStore;
    private readonly StudentModel _student;
    private readonly HttpClient _client;

    public NavigateToSearchPageCommand(NavigationStore navigation, HttpClient client, StudentModel student)
    {
        _navigationStore = navigation;
        _student = student;
        _client = client;
    }
    public override void Execute(object? parameter)
    {
        _navigationStore.CurrentViewModel = new SearchPageVM(_navigationStore, _client, _student);
    }
}
