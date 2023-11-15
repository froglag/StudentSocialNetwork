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
using ApplicationDbContext.Migrations;

namespace ViewModel.Commands
{
    public class GetChatMessagesCommand : CommandBase
    {
        private ReservoomDbContext _context;
        private StudentModel? _student;
        private ICollection<StudentModel?>? _participants;
        private IEnumerable<MessageCollection>? _messageContent;
        private int? _friendId;

        public GetChatMessagesCommand(ReservoomDbContext context, StudentModel? student, IEnumerable<MessageCollection>? messageContent, int? friendId)
        {
            _context = context;
            _student = student;
            _messageContent = messageContent;
            _friendId = friendId; 
        }
        public override void Execute(object? parameter)
        {
            int? friendId = parameter as int?;

            _friendId = friendId;

            var friend = new GetStudentInfoById(_context).Do(friendId);
            if (_participants != null)
            {
                _participants.Add(_student);
                _participants.Add(friend);


                var messages = new GetChatMessages(_context).Do(_participants);
                if(messages != null && _messageContent != null && _student != null)
                {
                    foreach (var m in messages)
                    {
                        _messageContent.Append(new MessageCollection
                        {
                            Messages = m,
                            FriendId = friendId,
                            StudentId = _student.StudentId
                        });
                    }
                }
                
            }
        }
    }
}
