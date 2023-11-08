using ApplicationDbContext;
using ApplicationDbContext.Models;
using Model.Get;
using ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using static ViewModel.MainPageVM;
using Microsoft.Win32.SafeHandles;

namespace ViewModel.Commands
{
    public class GetChatMessagesCommand : CommandBase
    {
        private readonly ReservoomDbContext _context;
        private readonly StudentModel _student;
        private ICollection<StudentModel>? _participants;
        private IEnumerable<MessageCollection>? _messagesCollection;
        private int studentId;
        private int friendId;


        public GetChatMessagesCommand(ReservoomDbContext context, StudentModel student, IEnumerable<MessageCollection>? messagesCollection)
        {
            _context = context;
            _student = student;
            _messagesCollection = messagesCollection;
    }
        public override void Execute(object? parameter)
        {
            _participants = new List<StudentModel>();
            if(parameter is StudentModel friend)
            {
                _participants.Add(_student);
                _participants.Add(friend);
                studentId = _student.StudentId;
                friendId = friend.StudentId;
            }
            
            var messages = new ObservableCollection<MessageModel>(new GetChatMessages(_context).Do(_participants));
            foreach (var m in messages)
            {
                _messagesCollection.Append(new MessageCollection
                {
                    Messages = m,
                    StudentId = studentId,
                    FriendId = friendId
                });
            }
        }
    }
}
