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
public class NavigateToSinginPageCommand : CommandBase
{
    private readonly NavigationStore _navigationStore;
    private ReservoomDbContext _context;

    public NavigateToSinginPageCommand(ReservoomDbContext context, NavigationStore navigation)
    {
        _context = context;
        _navigationStore = navigation;
    }
    public override void Execute(object? parameter)
    {
        _navigationStore.CurrentViewModel = new SighinVM(_context, _navigationStore);
    }
}
