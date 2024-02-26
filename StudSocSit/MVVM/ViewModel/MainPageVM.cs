using ApplicationDbContext;
using ApplicationDbContext.Models;
using StudentApplication.Get;
using System.Collections.Generic;
using System.Windows.Input;
using System.Collections.ObjectModel;
using StudSocSit.Store;
using Commands;
using System.Linq;

namespace ViewModel;
public class MainPageVM : ViewModelBase
{
    private readonly StudentModel _student;
    private List<StudentModel> friends;
    private readonly ReservoomDbContext _context;
    private List<MessageCollection>? _messagesCollection;
    private NavigationStore _navigationStore;
    private int? frindId;
    private string? message;

    public ICommand GetMessages { get; }
    public ICommand NavigationToSearchPage { get; }
    public ICommand NavigationToAccountSettingPage { get; }
    public ICommand NavigationToLoginPage { get; }
    public ICommand NavigationToFriendRequest {  get; }
    public ICommand AddMessage {  get; }

    public MainPageVM(ReservoomDbContext context, NavigationStore navigationStore, StudentModel student)
    {
        _student = student;
        _context = context;
        _navigationStore = navigationStore;
        friends = new List<StudentModel>();
        var friendsIdentity = _context.Friends.Where(f => f.StudentId == _student.StudentId).ToList();
        if(friendsIdentity != null)
        {
            foreach(var f in friendsIdentity)
            {
                var friend = _context.Student.FirstOrDefault(s => s.StudentId == f.FriendId);
                if (friend != null)
                {
                    friends.Add(friend);
                }
                
            }
        }

        GetMessages = new GetChatMessagesCommand(_context, this);
        NavigationToSearchPage = new NavigateToSearchPageCommand(context, _navigationStore, student);
        NavigationToAccountSettingPage = new NavigateToAccountSettingPageCommand(context, _navigationStore, student);
        NavigationToLoginPage = new NavigateToLoginPageCommand(context, _navigationStore);
        NavigationToFriendRequest = new NavigateToFriendRequestPageCommand(context, _navigationStore, student);
        AddMessage = new AddMessageCommand(_context, this);
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
    public int? FriendId
    {
        get => frindId;
        set
        {
            frindId = value;
            OnPropertyChanged(nameof(FriendId));
        }
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
