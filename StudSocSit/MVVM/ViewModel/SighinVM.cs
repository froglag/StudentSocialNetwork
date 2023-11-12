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
    private AddStudentToDb.Request? _addStudentRequest;
    public ICommand RegistrationSubmit { get;}
    public ICommand NavigationToLoginPage { get;}

    public SighinVM(ReservoomDbContext context, NavigationStore navigationStore)
    {
        _addStudentRequest = new AddStudentToDb.Request();
        RegistrationSubmit = new RegistrationSubmitCommand(_addStudentRequest, context, navigationStore);
        NavigationToLoginPage = new NavigateToLoginPageCommand(context, navigationStore);
    }

    public string? UserName
    {
        get => _addStudentRequest.UserName;
        set
        {
            _addStudentRequest.UserName = value;
            OnPropertyChanged(nameof(UserName));
        }
    }

    public string? Password
    {
        get => _addStudentRequest.Password;
        set
        {
            _addStudentRequest.Password = value;
            OnPropertyChanged(nameof(Password));
        }
    }
    public string? FirstName
    {
        get => _addStudentRequest.FirstName;
        set
        {
            _addStudentRequest.FirstName = value;
            OnPropertyChanged(nameof(FirstName));
        }
    }
    public string? LastName
    {
        get => _addStudentRequest.LastName;
        set
        {
            _addStudentRequest.LastName = value;
            OnPropertyChanged(nameof(LastName));
        }
    }
    public string? Email
    {
        get => _addStudentRequest.Email;
        set
        {
            _addStudentRequest.Email = value;
            OnPropertyChanged(nameof(Email));
        }
    }
    public int? PhoneNumber
    {
        get => _addStudentRequest.PhoneNumber;
        set
        {
            _addStudentRequest.PhoneNumber = value;
            OnPropertyChanged(nameof(PhoneNumber));
        }
    }
    public string? FacultyName
    {
        get => _addStudentRequest.FacultyName;
        set
        {
            _addStudentRequest.FacultyName = value;
            OnPropertyChanged(nameof(FacultyName));
        }
    }
    public string? Specialization
    {
        get => _addStudentRequest.Specialization;
        set
        {
            _addStudentRequest.Specialization = value;
            OnPropertyChanged(nameof(Specialization));
        }
    }
}
