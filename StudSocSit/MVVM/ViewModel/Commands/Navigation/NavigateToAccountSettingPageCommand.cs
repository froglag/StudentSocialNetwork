using ApplicationDbContext;
using ApplicationDbContext.Models;
using Microsoft.EntityFrameworkCore;
using StudSocSit.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using ViewModel.Commands;

namespace Commands;
public class NavigateToAccountSettingPageCommand : CommandBase
{
    private ReservoomDbContext _context;
    private StudentModel? _student;
    private readonly NavigationStore _navigationStore;
    public NavigateToAccountSettingPageCommand(ReservoomDbContext context, NavigationStore navigationStore, StudentModel? student)
    {
        _context = context;
        _student = student;
        _navigationStore = navigationStore;
    }
    public override void Execute(object? parameter)
    {
        _navigationStore.CurrentViewModel = new AccountSettingVM(_context, _navigationStore, _student);
    }
}
