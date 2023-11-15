using ApplicationDbContext;
using ApplicationDbContext.Models;
using StudSocSit.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using ViewModel.Commands;

namespace Commands;
public class NavigateToFriendRequestPageCommand : CommandBase
{
    private NavigationStore _navigationStore;
    private ReservoomDbContext _context;
    private StudentModel _student;
    public NavigateToFriendRequestPageCommand(ReservoomDbContext context, NavigationStore navigationStore, StudentModel student)
    {
        _context = context;
        _navigationStore = navigationStore;
        _student = student;
    }

    public override void Execute(object? parameter)
    {
        _navigationStore.CurrentViewModel = new FriendRequestPageVM(_context, _navigationStore, _student);
    }
}
