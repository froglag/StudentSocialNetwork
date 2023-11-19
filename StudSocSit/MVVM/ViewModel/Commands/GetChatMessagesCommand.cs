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
        private ReservoomDbContext _context;
        private readonly MainPageVM _mainPageVM;

        public GetChatMessagesCommand(ReservoomDbContext context, MainPageVM mainPageVM)
        {
            _context = context;
            _mainPageVM = mainPageVM;
        }
        public override void Execute(object? parameter)
        {
            _mainPageVM.MessageContent = null;
            var friendId = parameter as int?;
            if (friendId != null)
            {
                _mainPageVM.FriendId = friendId;

                var chat = _context.Chat.FirstOrDefault(c => (c.FirstStudentId == _mainPageVM.StudentInfo.StudentId && c.SecondStudentId == (int)_mainPageVM.FriendId) || (c.FirstStudentId == (int)_mainPageVM.FriendId && c.SecondStudentId == _mainPageVM.StudentInfo.StudentId));
                if (chat != null)
                {
                    var chatId = chat.ChatId;
                    var messages = _context.Message.Where(m => m.ChatId == chatId);

                    if (friendId != null && messages != null)
                    {
                        if (_mainPageVM.MessageContent == null)
                        {
                            _mainPageVM.MessageContent = new List<MessageCollection>();
                        }

                        foreach (var message in messages)
                        {
                            _mainPageVM.MessageContent.Add(new MessageCollection
                            {
                                Messages = message,
                                StudentId = _mainPageVM.StudentInfo.StudentId,
                                FriendId = friendId,
                            });
                        }

                    }
                }
            }
           
        }
    }
}
