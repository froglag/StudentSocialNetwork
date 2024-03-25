using StudSocSit.Store;
using System.Windows.Input;
using Commands;

namespace ViewModel;
public class AccountSettingVM : ViewModelBase
{
    private StudentModel? _student;
    public ICommand NavigationToMainPage { get; }
    public ICommand UpdateUserInfo { get; }
    public ICommand NavigationToAccountSettingPage { get; }
    public ICommand NavigationToLoginPage { get; }

    public AccountSettingVM(NavigationStore navigationStore, StudentModel? student)
    {
        _student = student;
        NavigationToMainPage = new NavigateToMainPageCommand(context, navigationStore, student);
        UpdateUserInfo = new UpdateUserInfoCommand(context, _student);
        NavigationToAccountSettingPage = new NavigateToAccountSettingPageCommand(context, navigationStore, student);
        NavigationToLoginPage = new NavigateToLoginPageCommand(context, navigationStore);
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

    public int? Phonenumber
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
