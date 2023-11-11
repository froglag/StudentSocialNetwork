using ApplicationDbContext;
using ApplicationDbContext.Models;
using Commands;
using Model.Create;
using StudSocSit.Store;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel;
public class SighinVM : ViewModelBase
{
    private AddStudentToDb.Request? _studentInfo;
    public ICommand RegistrationSubmit { get;}
    public ICommand NavigationToLoginPage { get;}

    public SighinVM(ReservoomDbContext context, NavigationStore navigationStore)
    {
        RegistrationSubmit = new RegistrationSubmitCommand(_studentInfo, context, navigationStore);
        NavigationToLoginPage = new NavigateToLoginPageCommand(context, navigationStore);
    }

    public AddStudentToDb.Request? StudentInfo
    {
        get => _studentInfo;
        set
        {
            _studentInfo = value;
            OnPropertyChanged(nameof(StudentInfo));
        }
    }
}
