using MVVM.Model.DataFields;
using StudSocSit.Store;
using System.Net.Http;
using ViewModel;
using ViewModel.Commands;

namespace Commands;
public class NavigateToFriendRequestPageCommand : CommandBase
{
    private NavigationStore _navigationStore;
    private StudentModel _student;
    private HttpClient _client;
    private string _JWT;

    public NavigateToFriendRequestPageCommand(NavigationStore navigationStore, HttpClient client, StudentModel student, string JWT)
    {
        _navigationStore = navigationStore;
        _student = student;
        _client = client;
        _JWT = JWT;
    }

    public override void Execute(object? parameter)
    {
        _navigationStore.CurrentViewModel = new FriendRequestPageVM(_navigationStore, _client, _student, _JWT);
    }
}
