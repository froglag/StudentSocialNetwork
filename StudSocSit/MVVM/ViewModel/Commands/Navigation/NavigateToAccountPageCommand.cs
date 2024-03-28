using MVVM.Model;
using MVVM.Model.DataFields;
using StudSocSit.Store;
using System.Net.Http;
using ViewModel;
using ViewModel.Commands;

namespace Commands;
public class NavigateToAccountPageCommand : CommandBase
{
    private StudentModel _student;
    private readonly NavigationStore _navigationStore;
    private readonly HttpClient _client;

    public NavigateToAccountPageCommand(NavigationStore navigationStore, HttpClient client, StudentModel student)
    {
        _student = student;
        _navigationStore = navigationStore;
        _client = client;
    }
    public override void Execute(object? parameter)
    {
        var friendId = (int)parameter;
        var friend = new GetStudentInfoById(_client).Do(friendId);
        _navigationStore.CurrentViewModel = new AccountPageVM(_navigationStore, _client, _student, friend);
    }
}
