using Commands;
using StudSocSit.Store;
using System.Net.Http;
using System.Windows.Input;

namespace ViewModel;
public class LoginVM : ViewModelBase
{
    private HttpClient _client;
    private UserAuth userAuth;
    public ICommand Authentication { get; }
    public ICommand NavigateToSighinPage {  get; }

    public LoginVM(NavigationStore navigation, HttpClient client)
    {
        _client = client;
        userAuth = new UserAuth();
        Authentication = new AuthenticationCommand(navigation, _client, userAuth);
        NavigateToSighinPage = new NavigateToSinginPageCommand(navigation, _client);
    }

    public string? UserName
    {
        get { return userAuth.UserName; }
        set 
        { 
            userAuth.UserName = value;
            OnPropertyChanged(nameof(UserName));
        }
    }

    public string? Password
    {
        get { return userAuth.Password; }
        set 
        { 
            userAuth.Password = value;
            OnPropertyChanged(nameof(Password));
        }
    }

    public class UserAuth
    {
        public string? UserName { get; set;}
        public string? Password { get; set;}
    }
}
