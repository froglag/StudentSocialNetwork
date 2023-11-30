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
using ViewModel.Commands;

namespace Commands;

/// <summary>
/// This command class handles the retrieval of chat messages and updates the ViewModel accordingly.
/// </summary>
public class GetChatMessagesCommand : CommandBase
{
    private ReservoomDbContext _context;
    private readonly MainPageVM _mainPageVM;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetChatMessagesCommand"/> class.
    /// </summary>
    /// <param name="context">The database context used for data operations.</param>
    /// <param name="mainPageVM">The ViewModel associated with the main page.</param>
    public GetChatMessagesCommand(ReservoomDbContext context, MainPageVM mainPageVM)
    {
        _context = context;
        _mainPageVM = mainPageVM;
    }

    /// <summary>
    /// Executes the command to retrieve chat messages and update the ViewModel.
    /// </summary>
    /// <param name="parameter">The friend identifier associated with the chat.</param>
    public override void Execute(object? parameter)
    {
        // Clear existing message content
        _mainPageVM.MessageContent = null;

        var friendId = parameter as int?;

        // Check if friendId is not null
        if (friendId != null)
        {
            // Set the FriendId property in the ViewModel
            _mainPageVM.FriendId = friendId;

            // Find the chat between the logged-in student and the friend
            var chat = _context.Chat.FirstOrDefault(c => (c.FirstStudentId == _mainPageVM.StudentInfo.StudentId && c.SecondStudentId == (int)_mainPageVM.FriendId) || (c.FirstStudentId == (int)_mainPageVM.FriendId && c.SecondStudentId == _mainPageVM.StudentInfo.StudentId));

            // If the chat exists, retrieve messages
            if (chat != null)
            {
                var chatId = chat.ChatId;
                var messages = _context.Message.Where(m => m.ChatId == chatId);

                // Check if messages and friendId are not null
                if (friendId != null && messages != null)
                {
                    // Initialize MessageContent list if null
                    if (_mainPageVM.MessageContent == null)
                    {
                        _mainPageVM.MessageContent = new List<MessageCollection>();
                    }

                    // Add messages to the MessageContent list
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

