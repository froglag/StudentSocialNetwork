using ApplicationDbContext;
using StudSocSit.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using ViewModel.Commands;

namespace Commands;
public class NavigateToLoginPageCommand : CommandBase
{
    private readonly NavigationStore _navigationStore;
    private ReservoomDbContext _context;

    public NavigateToLoginPageCommand(ReservoomDbContext context, NavigationStore navigation)
    {
        _context = context;
        _navigationStore = navigation;
    }
    public override void Execute(object? parameter)
    {
        _navigationStore.CurrentViewModel = new LoginVM(_context, _navigationStore);
    }
}
