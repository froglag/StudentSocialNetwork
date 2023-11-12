using ApplicationDbContext;
using StudSocSit.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ViewModel;
using ViewModel.Commands;
using static ViewModel.LoginVM;

namespace Commands;

public class AuthenticationCommand : CommandBase
{
    private ReservoomDbContext _context;
    private NavigationStore? _navigationStore;
    private UserAuth _userAuth;
    public AuthenticationCommand(ReservoomDbContext context, NavigationStore navigationStore, UserAuth userAuth)
    {
        _context = context;
        _navigationStore = navigationStore;
        _userAuth = userAuth;
    }
    public override void Execute(object? parameter)
    {
        try
        {
            var user = _context.User.Where(u => u.UserName == _userAuth.UserName && u.Password == _userAuth.Password).First();
            _navigationStore.CurrentViewModel = new MainPageVM(_context, user.Student);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Wronge Login or Password");
        }
    }
}
