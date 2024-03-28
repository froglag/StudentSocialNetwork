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

    public NavigateToFriendRequestPageCommand(NavigationStore navigationStore, HttpClient client, StudentModel student)
    {
        _navigationStore = navigationStore;
        _student = student;
        _client = client;
    }

    public override void Execute(object? parameter)
    {
        _navigationStore.CurrentViewModel = new FriendRequestPageVM(_navigationStore, _client, _student);
    }
}
