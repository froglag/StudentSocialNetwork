using ApplicationDbContext;
using ApplicationDbContext.Models;
using Microsoft.EntityFrameworkCore;
using StudentApplication.Get;
using StudSocSit.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using ViewModel.Commands;

namespace Commands;
public class NavigateToAccountPageCommand : CommandBase
{
    private StudentModel? _student;
    private ReservoomDbContext _context;
    private readonly NavigationStore _navigationStore;
    public NavigateToAccountPageCommand(ReservoomDbContext context, NavigationStore navigationStore, StudentModel? student)
    {
        _student = student;
        _context = context;
        _navigationStore = navigationStore;
    }
    public override void Execute(object? parameter)
    {
        var friendId = (int)parameter;
        var friend = new GetStudentInfoById(_context).Do(friendId);
        _navigationStore.CurrentViewModel = new AccountPageVM(_context, _navigationStore, _student, friend);
    }
}
