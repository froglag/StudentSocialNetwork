using ApplicationDbContext;
using ApplicationDbContext.Models;
using Model.Create;
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
public class RegistrationSubmitCommand : CommandBase
{
    private AddStudentToDb.Request? _studentInfo;
    private ReservoomDbContext _context;
    private NavigationStore _navigationStore;

    public RegistrationSubmitCommand(AddStudentToDb.Request? studentInfo, ReservoomDbContext context, NavigationStore navigationStore)
    {
        _studentInfo = studentInfo;
        _context = context;
        _navigationStore = navigationStore;
    }
    public override void Execute(object? parameter)
    {
        if (_studentInfo.UserName ==  null || _studentInfo.Password == null || _studentInfo.FirstName == null)
        {
            MessageBox.Show("Not all complited");
        }
        else
        {
            var addStudent = new AddStudentToDb(_context);
            addStudent.Do(_studentInfo);
            _navigationStore.CurrentViewModel = new LoginVM(_context, _navigationStore);
        }


    }
}
