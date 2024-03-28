using Commands;
using StudSocSit.Store;
using System.Net.Http;
using System.Windows.Input;

namespace ViewModel;
public class SighupVM : ViewModelBase
{
    private AddStudentRequest addStudentRequest;
    private HttpClient _client;

    public ICommand RegistrationSubmit { get;}
    public ICommand NavigationToLoginPage { get;}

    public SighupVM(NavigationStore navigationStore, HttpClient client)
    {
        addStudentRequest = new AddStudentRequest();
        _client = client;
        RegistrationSubmit = new RegistrationSubmitCommand(this ,navigationStore, _client);
        NavigationToLoginPage = new NavigateToLoginPageCommand(navigationStore, _client);
    }

    public string UserName
    {
        get => addStudentRequest.UserName;
        set
        {
            addStudentRequest.UserName = value;
            OnPropertyChanged(nameof(UserName));
        }
    }

    public string Password
    {
        get => addStudentRequest.Password;
        set
        {
            addStudentRequest.Password = value;
            OnPropertyChanged(nameof(Password));
        }
    }
    public string FirstName
    {
        get => addStudentRequest.FirstName;
        set
        {
            addStudentRequest.FirstName = value;
            OnPropertyChanged(nameof(FirstName));
        }
    }
    public string? LastName
    {
        get => addStudentRequest.LastName;
        set
        {
            addStudentRequest.LastName = value;
            OnPropertyChanged(nameof(LastName));
        }
    }
    public string? Email
    {
        get => addStudentRequest.Email;
        set
        {
            addStudentRequest.Email = value;
            OnPropertyChanged(nameof(Email));
        }
    }
    public string? PhoneNumber
    {
        get => addStudentRequest.PhoneNumber;
        set
        {
            addStudentRequest.PhoneNumber = value;
            OnPropertyChanged(nameof(PhoneNumber));
        }
    }
    public string? FacultyName
    {
        get => addStudentRequest.FacultyName;
        set
        {
            addStudentRequest.FacultyName = value;
            OnPropertyChanged(nameof(FacultyName));
        }
    }
    public string? Specialization
    {
        get => addStudentRequest.Specialization;
        set
        {
            addStudentRequest.Specialization = value;
            OnPropertyChanged(nameof(Specialization));
        }
    }

    public class AddStudentRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set;}
        public string? LastName { get; set; }
        public string FirstName { get; set;}
        public string? FacultyName { get; set; }
        public string? Specialization { get; set;}
    }
}
