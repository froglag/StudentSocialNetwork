using ApplicationDbContext;
using ApplicationDbContext.Models;
using Model.Create;
using StudSocSit.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Commands;

namespace Commands;

/// <summary>
/// This command class handles the creation and execution of a friend request.
/// </summary>
public class MakeFriendRequestCommand : CommandBase
{
    private ReservoomDbContext _context;
    private StudentModel? _student;
    private NavigationStore _navigationStore;

    /// <summary>
    /// Initializes a new instance of the <see cref="MakeFriendRequestCommand"/> class.
    /// </summary>
    /// <param name="context">The database context used for data operations.</param>
    /// <param name="navigationStore">The navigation store for managing navigation within the application.</param>
    /// <param name="student">The student associated with the command.</param>
    public MakeFriendRequestCommand(ReservoomDbContext context, NavigationStore navigationStore, StudentModel? student)
    {
        _context = context;
        _navigationStore = navigationStore;
        _student = student;
    }

    /// <summary>
    /// Executes the command to create and send a friend request.
    /// </summary>
    /// <param name="parameter">The friend identifier to whom the friend request is sent.</param>
    public override void Execute(object? parameter)
    {
        // Check if the student is not null
        if (_student != null)
        {
            // Extract friendId from the parameter
            var friendId = parameter as int?;

            // Create and send a friend request
            new AddFriendRiquest(_context).Do(new AddFriendRiquest.Request
            {
                SenderId = _student.StudentId,
                ReceiverId = friendId
            });
        }
    }
}

