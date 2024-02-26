using ApplicationDbContext;
using ApplicationDbContext.Models;
using StudentApplication.Create;
using StudentApplication.Get;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using ViewModel.Commands;

namespace Commands;

/// <summary>
/// This command class handles the addition of a message to a chat, updating the database accordingly.
/// </summary>
public class AddMessageCommand : CommandBase
{
    private ReservoomDbContext _context;
    private readonly MainPageVM _mainPageVM;

    /// <summary>
    /// Initializes a new instance of the <see cref="AddMessageCommand"/> class.
    /// </summary>
    /// <param name="context">The database context used for data operations.</param>
    /// <param name="mainPageVM">The ViewModel associated with the main page.</param>
    public AddMessageCommand(ReservoomDbContext context, MainPageVM mainPageVM)
    {
        _context = context;
        _mainPageVM = mainPageVM;
    }

    /// <summary>
    /// Executes the command to add a message to a chat.
    /// </summary>
    /// <param name="parameter">The friend identifier associated with the chat.</param>
    public override void Execute(object? parameter)
    {
        // Check if FriendId is not null
        if (_mainPageVM.FriendId != null)
        {
            // Find the chat between the logged-in student and the friend
            var myChat = _context.Chat.FirstOrDefault(c => (c.FirstStudentId == _mainPageVM.StudentInfo.StudentId && c.SecondStudentId == (int)_mainPageVM.FriendId) || (c.FirstStudentId == (int)_mainPageVM.FriendId && c.SecondStudentId == _mainPageVM.StudentInfo.StudentId));

            // If no chat exists, create a new chat
            if (myChat == null)
            {
                new AddChatToDb(_context).Do(new AddChatToDb.Request
                {
                    FirstStudentId = _mainPageVM.StudentInfo.StudentId,
                    SecondStudentId = (int)_mainPageVM.FriendId,
                });
            }

            // Retrieve the chat again
            myChat = _context.Chat.FirstOrDefault(c => (c.FirstStudentId == _mainPageVM.StudentInfo.StudentId && c.SecondStudentId == (int)_mainPageVM.FriendId) || (c.FirstStudentId == (int)_mainPageVM.FriendId && c.SecondStudentId == _mainPageVM.StudentInfo.StudentId));

            // If the chat exists, add the message to the chat
            if (myChat != null)
            {
                new AddMessageToDb(_context).Do(new AddMessageToDb.Request
                {
                    AuthorId = _mainPageVM.StudentInfo.StudentId,
                    ChatId = myChat.ChatId,
                    Text = _mainPageVM.Message
                });
            }

            // Execute a command to retrieve and update chat messages
            new GetChatMessagesCommand(_context, _mainPageVM).Execute(_mainPageVM.FriendId);
        }
    }
}

