using System.Collections.Generic;
using System.Net.Http;
using System.Windows.Input;
using Commands;
using MVVM.Model;
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
    private List<StudentModel> friends;
    private int friendId;


    public ICommand GetMessages { get; }
    public ICommand AddMessage { get; }
    public ICommand NavigationToSearchPage { get; }
    public ICommand NavigationToAccountSettingPage { get; }
    public ICommand NavigationToLoginPage { get; }
    public ICommand NavigationToFriendRequest {  get; }

    public MainPageVM(NavigationStore navigationStore, HttpClient client, StudentModel student, string JWT)
    {
        _client = client;
        _student = student;
        _navigationStore = navigationStore;

        friends = new GetFriendsInfo(_client, JWT).Do();
        
        GetMessages = new GetChatMessagesCommand(_client, this, JWT);
        AddMessage = new AddMessageCommand(this, _client, JWT);

        NavigationToSearchPage = new NavigateToSearchPageCommand(navigationStore, client, student, JWT);
        NavigationToAccountSettingPage = new NavigateToAccountSettingPageCommand(navigationStore, client, student, JWT);
        NavigationToLoginPage = new NavigateToLoginPageCommand(navigationStore, client);
        NavigationToFriendRequest = new NavigateToFriendRequestPageCommand(navigationStore, client, student, JWT);

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

    public int FriendId
    {
        get => friendId;
        set
        {
            friendId = value;
            OnPropertyChanged(nameof(FriendId));
        }
    }
}
