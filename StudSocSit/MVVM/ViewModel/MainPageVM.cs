using ApplicationDbContext;
using ApplicationDbContext.Models;
using Model.Get;
using ViewModel.Commands;
using System.Collections.Generic;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace ViewModel;
public class MainPageVM : ViewModelBase
{
    private readonly ReservoomDbContext _context;
    private StudentModel _student;
    private IEnumerable<MessageCollection>? _messagesCollection;
    public ICommand GetMessages { get; }


    public MainPageVM(ReservoomDbContext context, StudentModel student)
    {
        _context = context;
        _student = student;
        GetMessages = new GetChatMessagesCommand(_context, _student, _messagesCollection);
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
    public StudentModel StudentInfo
    {
        get => _student;
        set
        {
            _student = value;
            OnPropertyChanged(nameof(StudentInfo));
        }
    }
}
