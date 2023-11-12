using ApplicationDbContext;
using ApplicationDbContext.Models;
using Model.Get;
using ViewModel.Commands;
using System.Collections.Generic;
using System.Windows.Input;
using System.Collections.ObjectModel;
using StudSocSit.Store;
using Commands;

namespace ViewModel;
public class MainPageVM : ViewModelBase
{
    private readonly ReservoomDbContext _context;
    private StudentModel? _student;
    private IEnumerable<MessageCollection>? _messagesCollection;
    private NavigationStore _navigationStore;

    public ICommand GetMessages { get; }
    public ICommand NavigationToSearchPage { get; }

    public MainPageVM(ReservoomDbContext context, NavigationStore navigationStore, StudentModel? student)
    {
        _context = context;
        _navigationStore = navigationStore;
        StudentInfo = student;
        GetMessages = new GetChatMessagesCommand(_context, _student, _messagesCollection);
        NavigationToSearchPage = new NavigateToSearchPageCommand(context, _navigationStore, student);
    }
    
    public IEnumerable<MessageCollection>? MessageContent
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
        public int StudentId { get; set; }
        public int FriendId { get; set; }
    }
    public StudentModel? StudentInfo
    {
        get => _student;
        set
        {
            _student = value;
            OnPropertyChanged(nameof(StudentInfo));
        }
    }
}
