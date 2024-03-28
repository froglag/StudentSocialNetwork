using StudSocSit.Store;
using System.Windows.Input;
using Commands;
using MVVM.Model.DataFields;
using System.Net.Http;

namespace ViewModel;
public class AccountSettingVM : ViewModelBase
{
    private StudentModel _student;
    public ICommand NavigationToMainPage { get; }
    public ICommand UpdateUserInfo { get; }
    public ICommand NavigationToAccountSettingPage { get; }
    public ICommand NavigationToLoginPage { get; }

    public AccountSettingVM(NavigationStore navigationStore, HttpClient client, StudentModel student)
    {
        _student = student;
        NavigationToMainPage = new NavigateToMainPageCommand(navigationStore, client, _student);
        UpdateUserInfo = new UpdateUserInfoCommand(client, _student);
        NavigationToAccountSettingPage = new NavigateToAccountSettingPageCommand(navigationStore, client, _student);
        NavigationToLoginPage = new NavigateToLoginPageCommand(navigationStore, client);
    }

    public string FirstName
    {
        get => _student.FirstName;
        set
        {
            _student.FirstName = value;
            OnPropertyChanged(nameof(FirstName));
        }
    }

    public string LastName
    {
        get => _student.LastName;
        set
        {
            _student.LastName = value;
            OnPropertyChanged(nameof(LastName));
        }
    }

    public string Email
    {
        get => _student.Email;
        set
        {
            _student.Email = value;
            OnPropertyChanged(nameof(Email));
        }
    }

    public string? Phonenumber
    {
        get => _student.PhoneNumber;
        set
        {
            _student.PhoneNumber = value;
            OnPropertyChanged(nameof(Phonenumber));
        }
    }

    public string FacultyName
    {
        get => _student.FacultyName;
        set
        {
            _student.FacultyName = value;
            OnPropertyChanged(nameof(FacultyName));
        }
    }

    public string Specialization
    {
        get => _student.Specialization;
        set
        {
            _student.Specialization = value;
            OnPropertyChanged(nameof(Specialization));
        }
    }
}
