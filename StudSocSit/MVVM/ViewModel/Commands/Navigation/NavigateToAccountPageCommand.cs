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
    private readonly string _JWT;

    public NavigateToAccountPageCommand(NavigationStore navigationStore, HttpClient client, StudentModel student, string JWT)
    {
        _student = student;
        _navigationStore = navigationStore;
        _client = client;
        _JWT = JWT;
    }
    public override void Execute(object? parameter)
    {
        var friendId = (int)parameter;
        var friend = new GetStudentInfoById(_client, _JWT).Do(friendId);
        _navigationStore.CurrentViewModel = new AccountPageVM(_navigationStore, _client, _student, _JWT, friend);
    }
}
