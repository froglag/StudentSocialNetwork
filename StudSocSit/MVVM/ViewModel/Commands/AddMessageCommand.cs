using ApplicationDbContext;
using ApplicationDbContext.Models;
using Model.Create;
using Model.Get;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using ViewModel.Commands;

namespace Commands;
public class AddMessageCommand : CommandBase
{
    private ReservoomDbContext _context;
    private readonly MainPageVM _mainPageVM;
    public AddMessageCommand(ReservoomDbContext context, MainPageVM mainPageVM)
    {
        _context = context;
        _mainPageVM = mainPageVM;
    }
    public override void Execute(object? parameter)
    {
        
        if (_mainPageVM.FriendId != null)
        {
            var myChat = _context.Chat.FirstOrDefault(c => (c.FirstStudentId == _mainPageVM.StudentInfo.StudentId && c.SecondStudentId == (int)_mainPageVM.FriendId) || (c.FirstStudentId ==(int)_mainPageVM.FriendId && c.SecondStudentId == _mainPageVM.StudentInfo.StudentId));

            if(myChat == null)
            {
                new AddChatToDb(_context).Do(new AddChatToDb.Request
                {
                    FirstStudentId = _mainPageVM.StudentInfo.StudentId,
                    SecondStudentId = (int)_mainPageVM.FriendId,
                });
            }

            myChat = _context.Chat.FirstOrDefault(c => (c.FirstStudentId == _mainPageVM.StudentInfo.StudentId && c.SecondStudentId == (int)_mainPageVM.FriendId) || (c.FirstStudentId == (int)_mainPageVM.FriendId && c.SecondStudentId == _mainPageVM.StudentInfo.StudentId));
            if(myChat != null)
            {
                new AddMessageToDb(_context).Do(new AddMessageToDb.Request
                {
                    AuthorId = _mainPageVM.StudentInfo.StudentId,
                    ChatId = myChat.ChatId,
                    Text = _mainPageVM.Message
                });
            }

            new GetChatMessagesCommand(_context, _mainPageVM).Execute(_mainPageVM.FriendId);
        }
        
        
    }
}
