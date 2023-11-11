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

namespace Commands;

public class AuthenticationCommand : CommandBase
{
    private string? _userName;
    private string? _password;
    private ReservoomDbContext _context;
    private NavigationStore? _navigationStore;
    public AuthenticationCommand(ReservoomDbContext context ,string? userName, string? password)
    {
        _context = context;
        _userName = userName;
        _password = password;
    }
    public override void Execute(object? parameter)
    {
        try
        {
            var user = _context.User.Where(u => u.UserName == _userName && u.Password == _password).First();
            _navigationStore.CurrentViewModel = new MainPageVM(_context, user.Student);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Wronge Login or Password");
        }
    }
}
