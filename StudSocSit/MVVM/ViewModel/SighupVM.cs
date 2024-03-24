using Commands;
using StudSocSit.Store;
using System.Net.Http;
using System.Windows.Input;

namespace ViewModel;
public class SighupVM : ViewModelBase
{
    private HttpClient _client;
    private AddStudentRequest _addStudentRequest;

    public ICommand RegistrationSubmit { get;}
    public ICommand NavigationToLoginPage { get;}

    public SighupVM(NavigationStore navigationStore, HttpClient client, AddStudentRequest addStudentRequest)
    {
        _client = client;
        _addStudentRequest = addStudentRequest;
        RegistrationSubmit = new RegistrationSubmitCommand(this ,navigationStore, _client);
        NavigationToLoginPage = new NavigateToLoginPageCommand(navigationStore);
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
    public string? PhoneNumber
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

    class AddStudentRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set;}
        public string? LastName { get; set; }
        public string? FirstName { get; set;}
        public string? FacultyName { get; set; }
        public string? Specialization { get; set;}
    }
}
