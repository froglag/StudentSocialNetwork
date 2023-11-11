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
    private string? userName;
    private string? password;
    public ICommand Authentication { get; }
    public ICommand NavigateToSighinPage {  get; }

    public LoginVM(ReservoomDbContext context, NavigationStore navigation)
    {
        Authentication = new AuthenticationCommand(context, userName, password);
        NavigateToSighinPage = new NavigateToSinginPageCommand(context, navigation);
    }

    public string? UserName
    {
        get { return userName; }
        set { userName = value; }
    }

    public string? Password
    {
        get { return password; }
        set { password = value; }
    }

}
