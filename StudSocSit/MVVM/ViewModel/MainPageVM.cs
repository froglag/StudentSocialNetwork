using System.Collections.Generic;
using System.Net.Http;
using System.Windows.Input;
using MVVM.Model.DataFields;
using StudSocSit.Store;

namespace ViewModel;
public class MainPageVM : ViewModelBase
{
    private List<MessageCollection>? _messagesCollection;
    private HttpClient _client;
    private StudentModel _student;
    private NavigationStore _navigationStore;
    private string? message;

    public ICommand GetMessages { get; }
    public ICommand NavigationToSearchPage { get; }
    public ICommand NavigationToAccountSettingPage { get; }
    public ICommand NavigationToLoginPage { get; }
    public ICommand NavigationToFriendRequest {  get; }
    public ICommand AddMessage {  get; }

    public MainPageVM(NavigationStore navigationStore, HttpClient client StudentModel student)
    {
        _client = client;
        _student = student;
        _navigationStore = navigationStore;

        
    }
    public StudentModel StudentInfo
    {
        get => _student;
    }

    
    public List<MessageCollection>? MessageContent
    {
        get => _messagesCollection;
        set
        {
            _messagesCollection = value;
            OnPropertyChanged(nameof(MessageContent));
        }
    }

    public class MessageCollection
    {
        public MessageModel? Messages { get; set; }
        public int? StudentId { get; set; }
        public int? FriendId { get; set; }
    }
    public string? Message
    {
        get => message;
        set
        {
            message = value;
            OnPropertyChanged(nameof(Message));
        }
    }

    public List<StudentModel> Friends
    {
        get => friends;
    }
}
