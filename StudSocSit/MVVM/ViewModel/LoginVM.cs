using ApplicationDbContext;
using Commands;
using StudSocSit.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel;
public class LoginVM : ViewModelBase
{
    private UserAuth userAuth;
    public ICommand Authentication { get; }
    public ICommand NavigateToSighinPage {  get; }

    public LoginVM(ReservoomDbContext context, NavigationStore navigation)
    {
        userAuth = new UserAuth();
        Authentication = new AuthenticationCommand(context, navigation, userAuth);
        NavigateToSighinPage = new NavigateToSinginPageCommand(context, navigation);
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
