using MVVM.Model.DataFields;
using StudSocSit.Store;
using System.Net.Http;
using ViewModel;
using ViewModel.Commands;

namespace Commands;
public class NavigateToAccountSettingPageCommand : CommandBase
{
    private StudentModel _student;
    private readonly NavigationStore _navigationStore;
    private readonly HttpClient _client;
    private readonly string _JWT;

    public NavigateToAccountSettingPageCommand(NavigationStore navigationStore, HttpClient client, StudentModel student, string JWT)
    {
        _student = student;
        _navigationStore = navigationStore;
        _client = client;
        _JWT = JWT;
    }
    public override void Execute(object? parameter)
    {
        _navigationStore.CurrentViewModel = new AccountSettingVM(_navigationStore, _client, _student, _JWT);
    }
}
